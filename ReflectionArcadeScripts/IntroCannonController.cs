using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCannonController : MonoBehaviour
{
    public GameObject CannonTrapTop;
    private float DelayTime;
    public bool isCannonStarted = false;
    private bool isCannonUp = false;
    private bool isRotating = false;
    public Transform launchPosition;
    public GameObject ballPrefab;

	// Use this for initialization
	void Start ()
    {
        DelayTime = Random.Range(0.5f, 1.0f);
        StartCannon();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isCannonStarted)
        {
            if (!isCannonUp)
            {
                if (CannonTrapTop.transform.position.y < -0.3f)
                {
                    CannonTrapTop.transform.Translate(Vector3.up * 0.02f * Time.deltaTime);
                }
                else
                {
                    isCannonUp = true;
                }
            }
            else
            {
                if (!isRotating)
                {
                    var ball = (GameObject)Instantiate(ballPrefab, launchPosition.position, launchPosition.rotation);
                    ball.SetActive(true);
                    isRotating = true;
                }
                else
                {

                }
            }
        }

	}

    public void StartCannon()
    {
        StartCoroutine("RaiseTopDelay");
    }

    IEnumerator RaiseTopDelay()
    {
        yield return new WaitForSeconds(DelayTime);
        isCannonStarted = true;
    }


}
