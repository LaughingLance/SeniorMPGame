using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerHost : MonoBehaviour
{
    public string SceneName;

    private GameObject dataController;
    PlayerDataController playerData;

    public GameObject FadeObjectHolder;
    SceneFading fadeInOut;

    // Use this for initialization
    void Start()
    {
        fadeInOut = FadeObjectHolder.GetComponent<SceneFading>();
        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine("TransitionPauseTimer");
            playerData.Save();
            fadeInOut.FadeToBlack();
        }
    }

    IEnumerator TransitionPauseTimer()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneName);
    }
}
