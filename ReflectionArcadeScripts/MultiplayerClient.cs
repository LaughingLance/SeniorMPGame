using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerClient : MonoBehaviour
{
  //  LoginToMultiplayer multiplayerLogin;
  //  private string ParentGameObject;

    // Use this for initialization
    void Start ()
    {
  //      multiplayerLogin = NetworkManager.singleton.GetComponent<LoginToMultiplayer>();
	}

    private void OnCollisionEnter(Collision col)
    {
        /*
        if (col.gameObject.tag == "Player")
        {
            ParentGameObject = gameObject.transform.parent.ToString();
            switch (ParentGameObject)
            {
                case "MultiplayerMountainGame":
                    multiplayerLogin.SceneName = "multiplayerMountain";
                    break;
            }
            multiplayerLogin.ClientOrHost = "Client";
            multiplayerLogin.JoinMultiplayerGame();
        }
        */
    }
}
