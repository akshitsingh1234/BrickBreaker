using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ToLobby : MonoBehaviourPunCallbacks
{
    

    [PunRPC]
    void ChatMessage11()
    {

        result.text = "You win";
    }

    [PunRPC]
    void ChatMessage22()
    {
        result.text = "You lose";
    }
    public Text result;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        if ((GameManager.flagl == 0) && (GameManager.flagu == 1))                      
        {    if (PhotonNetwork.IsMasterClient)
            {
                result.text = "You lose";
                photonView.RPC("ChatMessage11", RpcTarget.Others);
            }
            else 
            {
                result.text = "You win";
                photonView.RPC("ChatMessage22", RpcTarget.Others);
            }
        }
        else if ((GameManager.flagl == 1) && (GameManager.flagu == 0))
        {
            if (PhotonNetwork.IsMasterClient)
            {
                result.text = "You win";
                photonView.RPC("ChatMessage22", RpcTarget.Others);
            }
            else
            {
                result.text = "You lose";
                photonView.RPC("ChatMessage11", RpcTarget.Others);
            }
        }
            
    }

    public void ChangeSceneendintro(string sceneName2)
    {
        //StartCoroutine(Disconnec());
        PhotonNetwork.LeaveRoom();       
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
        base.OnLeftRoom();
        GameManager.scorecollected2 = 0;
        GameManager.scorecollected1 = 0;
        GameManager.flagl = 0;
        GameManager.flagu = 0;
        GameManager.yourresultmaster=0;
        GameManager.yourresultclient=0;
}

    ///IEnumerator Disconnec()
    //{
    //PhotonNetwork.LeaveRoom();
    //while (PhotonNetwork.InRoom)
    //yield return null;
    //PhotonNetwork.LoadLevel("Lobby");
    //}

}
