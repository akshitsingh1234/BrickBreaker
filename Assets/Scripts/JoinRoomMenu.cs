using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class JoinRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InputField _roomjoinName;
 
    public void OnClick_JoinRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        PhotonNetwork.JoinRoom(_roomjoinName.text,null);
    }
}
