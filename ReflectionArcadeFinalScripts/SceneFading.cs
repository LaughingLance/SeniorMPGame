using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFading : MonoBehaviour
{
    void Start()
    {
     //   FadeToClear();
    }

    public void FadeToBlack()
    {
        StartCoroutine("FadeBlack");
    }

    IEnumerator FadeBlack()
    {

        CanvasGroup canvasGroupBlack = GetComponent<CanvasGroup>();
        while (canvasGroupBlack.alpha < 1)
        {
            canvasGroupBlack.alpha += Time.deltaTime;
            yield return null;
        }

        canvasGroupBlack.interactable = false;
    }

    public void FadeToClear()
    {
        StartCoroutine("FadeClear");
    }

    IEnumerator FadeClear()
    {
        CanvasGroup canvasGroupClear = GetComponent<CanvasGroup>();
        while (canvasGroupClear.alpha > 0)
        {
            canvasGroupClear.alpha -= Time.deltaTime;
            yield return null;
        }

        canvasGroupClear.interactable = false;

    }
}