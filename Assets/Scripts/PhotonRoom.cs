using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{

    private PhotonView PV;
    public int currentScene;
    public int multiplayScene;
    public GameObject pad1;
    public GameObject bal1;
    public GameObject pad2;
    public GameObject bal2;
    int playerCount;
    private GameObject cam;
    private Text resu;


    public static PhotonRoom PM;

    
       
   

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (PM)
            Destroy(this.gameObject);
        else 
            PhotonRoom.PM = this;    
    }

    void Start()
    {
        PV = GetComponent<PhotonView>();
        PhotonNetwork.AutomaticallySyncScene = true;
    }



    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    
}

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("Joined room successfully.", this);
        if (!PhotonNetwork.IsMasterClient)
            return;
        StartGame();
    }
    
    public  void OnDisconnected(Player player)
    {   if (PhotonNetwork.IsMasterClient)
        {
            GameManager.yourresultclient = 1;
            GameManager.yourresultmaster = 0;
        }
        else
        {
            GameManager.yourresultclient = 0;
            GameManager.yourresultmaster = 1;

        }


    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.buildIndex;
        if (currentScene == multiplayScene)
        {
            CreatePlayer();
        }
    }
    void StartGame()
    {
        if (!PhotonNetwork.IsMasterClient)
            return;
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        if (playerCount == 2)
        {
            PhotonNetwork.LoadLevel("SampleScene");

        }
    }

    void CreatePlayer()
    {
        cam = GameObject.Find("Main Camera");

        //int spawnPicker1 = Random.Range(0, GameSetup.GS.spawnPointsPaddle.Length);
        if (PhotonNetwork.IsMasterClient)
        {
            pad1 = PhotonNetwork.Instantiate("paddle", GameSetup.GS.spawnPointsPaddle[0].position, GameSetup.GS.spawnPointsPaddle[0].rotation, 0);
            bal1 = PhotonNetwork.Instantiate("ball", GameSetup.GS.spawnPointsBall[0].position, GameSetup.GS.spawnPointsBall[0].rotation, 0);
            cam.transform.position = new Vector3(0.43f, 0f, -14.0f);
            cam.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
            
        }
        else
        {
            pad2 = PhotonNetwork.Instantiate("paddle1", GameSetup.GS.spawnPointsPaddle[1].position, GameSetup.GS.spawnPointsPaddle[1].rotation, 0);
            bal2 = PhotonNetwork.Instantiate("ball1", GameSetup.GS.spawnPointsBall[1].position, GameSetup.GS.spawnPointsBall[1].rotation, 0);
            cam.transform.position = new Vector3(0.43f, 0f, 14.0f);
            cam.transform.Rotate(0.0f, 180.0f, 180.0f, Space.Self);
            
        }


    }


}
    
