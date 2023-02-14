using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;


public class PhotonManager : MonoBehaviourPunCallbacks, IConnectionCallbacks
{
    public string versionName = "0.1";
    public GameObject ConnectingPanel, ConnectedPanel, DisconectPanel;
    private LoadBalancingClient loadBalancingClient;
    //bool fal;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        ConnectingPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        DisconectPanel.SetActive(false);
        ConnectingPanel.SetActive(false);
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }



    void IConnectionCallbacks.OnDisconnected(DisconnectCause cause)
    {
        DisconectPanel.SetActive(true);
        ConnectedPanel.SetActive(false);
        ConnectingPanel.SetActive(false);
        PhotonNetwork.Disconnect();
            InvokeRepeating("Recover", 1.0f, 2.0f);
        
    }





    void Recover()
    {
        //fal = false;
        //if ((PhotonNetwork.IsConnected == false) && (fal == false))
        if(Application.internetReachability != NetworkReachability.NotReachable)
        { 
                PhotonNetwork.ConnectUsingSettings();
                DisconectPanel.SetActive(false);
                ConnectedPanel.SetActive(true);
                ConnectingPanel.SetActive(false);
                CancelInvoke("Recover");
   
       }
    }
}