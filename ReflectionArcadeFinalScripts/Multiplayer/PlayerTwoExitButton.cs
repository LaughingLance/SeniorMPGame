using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerTwoExitButton : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PlayerTwo")
        {
            NetworkManager.singleton.GetComponent<CustomNetworkMenu>().StopHostAndClient();
            SceneManager.LoadScene("lobby");
        }
    }
}
