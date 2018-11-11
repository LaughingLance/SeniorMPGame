using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerHost : MonoBehaviour
{
    //   LoginToMultiplayer multiplayerLogin;
    //   private string ParentGameObject;
    public string SceneName;

    private GameObject dataController;
    PlayerDataController playerData;

    // Use this for initialization
    void Start()
    {
        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();
        //      multiplayerLogin = NetworkManager.singleton.GetComponent<LoginToMultiplayer>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerData.Save();
            SceneManager.LoadScene(SceneName);
            /*
            ParentGameObject = gameObject.transform.parent.ToString();
            switch (ParentGameObject)
            {
                case "MultiplayerMountainGame":
                    multiplayerLogin.SceneName = "multiplayerMountain";
                    break;
            }            
            multiplayerLogin.ClientOrHost = "Host";
            multiplayerLogin.JoinMultiplayerGame();
            */
        }
    }
}
