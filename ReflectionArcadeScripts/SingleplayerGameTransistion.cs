using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleplayerGameTransistion : MonoBehaviour
{
    public string SceneName;
    public bool OkayToActivate = false;

    private GameObject dataController;
    PlayerDataController playerData;

    // Use this for initialization
    void Start ()
    {
        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();

        StartCoroutine("PauseTimer");
	}

    private void OnCollisionEnter(Collision col)
    {
        if (OkayToActivate)
        {
            playerData.Save();

            if (col.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneName);
            }
        }
    }

    IEnumerator PauseTimer()
    {
        yield return new WaitForSeconds(3f);
        OkayToActivate = true;
    }
}
