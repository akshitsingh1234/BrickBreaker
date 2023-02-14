using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuitoLobby : MonoBehaviour
{
    public void Changegtol(string sceneName1)
    {
        SceneManager.LoadScene("Lobby");
    }
}
