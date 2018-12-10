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

    public GameObject FadeObjectHolder;
    SceneFading fadeInOut;

    // Use this for initialization
    void Start ()
    {
        fadeInOut = FadeObjectHolder.GetComponent<SceneFading>();
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
                StartCoroutine("TransitionPauseTimer");
                playerData.Save();
                fadeInOut.FadeToBlack();
            }
        }
    }

    IEnumerator PauseTimer()
    {
        yield return new WaitForSeconds(3f);
        OkayToActivate = true;
    }

    IEnumerator TransitionPauseTimer()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneName);
    }
}
