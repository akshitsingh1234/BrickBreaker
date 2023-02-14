using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class LobbytoGui : MonoBehaviour
{
    public void Changeltog(string sceneName1)
    {
        SceneManager.LoadScene("Guide");
        if (PhotonNetwork.IsConnected == true)
        {
            Debug.Log("Starting Disconnect. . .");
            StartCoroutine(Disconnect());
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Connecting. . . ");
        }

    }

    IEnumerator Disconnect()
    {
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
        {
            yield return null;
            Debug.Log("Disconnecting. . .");
        }
        Debug.Log("DISCONNECTED!");
    }
}
