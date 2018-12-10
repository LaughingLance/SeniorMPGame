using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomNetworkMenu : MonoBehaviour
{
    private bool inLobby = false;
    public string ipAddressClient;
    public string portClient;

    public bool tempHostLaunch = false;

    public void StartServer()
    {
        NetworkManager.singleton.StartHost();
    }

    public void JoinClient()
    {
        
        if (ipAddressClient.Length > 0)
        {
            NetworkManager.singleton.networkAddress = ipAddressClient;
        }

        if (portClient.Length > 0)
        {
            int x;
            int.TryParse(portClient, out x);
            NetworkManager.singleton.networkPort = x;
        }

        if (inLobby)
        {
            GameObject.Find("Canvas").GetComponent<SceneFading>().FadeToBlack();
        }

        NetworkManager.singleton.StartClient();
    }

    public void StopHostAndClient()
    {
        NetworkManager.singleton.StopClient();
        NetworkManager.singleton.StopHost();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "multiplayerLobby")
        {
            inLobby = true;
        }
        else
        {
            inLobby = false;
        }
    }

    void Update()
    {
        if (tempHostLaunch)
        {
            StartServer();
            tempHostLaunch = false;
        }
    }
}
