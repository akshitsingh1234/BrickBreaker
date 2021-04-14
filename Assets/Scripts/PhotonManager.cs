using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;


public class PhotonManager : MonoBehaviourPunCallbacks
{
    public string versionName = "0.1";
    public GameObject ConnectingPanel, ConnectedPanel, DisconectPanel;
    

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
        if(!PhotonNetwork.InLobby)
        PhotonNetwork.JoinLobby();    
    }

    public override void OnJoinedLobby()
    {
        ConnectedPanel.SetActive(true);
       ConnectingPanel.SetActive(false);
    }
    

    public override void OnDisconnected(DisconnectCause cause)
    {
        DisconectPanel.SetActive(true);
        ConnectedPanel.SetActive(false);
        ConnectingPanel.SetActive(false);
        PhotonNetwork.Reconnect();
    }



    
}
