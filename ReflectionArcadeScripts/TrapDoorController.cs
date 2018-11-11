using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorController : MonoBehaviour
{
    public GameObject TrapDoorHinge;
    public GameObject MovingTargetPrefab;
    public Transform LaunchPosition;

    private float LastTargetLaunchTime;
    private float RandomTargetLaunchTime;

    public bool isOpening;
    public bool isMoving;

    private bool isTimeDelaySet;

    private float RandomLaunchPower;

    private Quaternion CloseRotation = Quaternion.Euler(0, 90, 0);
    private Quaternion OpenRotation = Quaternion.Euler(0, 90, 260);

    public GameObject controller;
    GameControllerSingle gameController;

    // Use this for initialization
    void Start ()
    {
        isOpening = false;
        isMoving = false;
        isTimeDelaySet = false;
        gameController = controller.GetComponent<GameControllerSingle>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameController.PlayerReady && gameController.StartPauseTimerComplete)
        {
            if (!isTimeDelaySet)
            {
                LastTargetLaunchTime = Time.time;
                RandomTargetLaunchTime = Random.Range(3f, 12f);
                isTimeDelaySet = true;
                isMoving = true;
                isOpening = true;
            }
            else
            {
                if (RandomTargetLaunchTime < Time.time - LastTargetLaunchTime)
                {
                    if (isMoving)
                    {
                        if (isOpening)
                        {
                            if (TrapDoorHinge.transform.rotation.eulerAngles.z == 0)
                            {
                                TrapDoorHinge.transform.Rotate(Vector3.forward * -20f * Time.deltaTime);
                            }
                            else if (TrapDoorHinge.transform.rotation.eulerAngles.z > 260)
                            {
                                TrapDoorHinge.transform.Rotate(Vector3.forward * -20f * Time.deltaTime);
                            }
                            else
                            {
                                TrapDoorHinge.transform.rotation = OpenRotation;
                                isMoving = false;
                                isOpening = false;

                                StartCoroutine("LaunchPause");
                            }
                        }
                        else // is closing
                        {
                            if (TrapDoorHinge.transform.rotation.eulerAngles.z < 359.5 || TrapDoorHinge.transform.rotation.eulerAngles.z < 0.5)
                            {
                                TrapDoorHinge.transform.Rotate(Vector3.forward * 20f * Time.deltaTime);
                            }
                            else
                            {
                                TrapDoorHinge.transform.rotation = CloseRotation;
                                isMoving = false;
                                isOpening = true;
                                isTimeDelaySet = false;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (TrapDoorHinge.transform.rotation.eulerAngles.z != 0)
            {
                if (TrapDoorHinge.transform.rotation.eulerAngles.z < 359.5 || TrapDoorHinge.transform.rotation.eulerAngles.z < 0.5)
                {
                    TrapDoorHinge.transform.Rotate(Vector3.forward * 20f * Time.deltaTime);
                }
                else
                {
                    TrapDoorHinge.transform.rotation = CloseRotation;
                    isMoving = false;
                    isOpening = true;
                    isTimeDelaySet = false;
                }
            }
        }
	}

    IEnumerator LaunchPause()
    {
        yield return new WaitForSeconds(0.5f);
        LaunchTarget();
    }

    private void LaunchTarget()
    {
        var target = (GameObject)Instantiate(MovingTargetPrefab, LaunchPosition.position, LaunchPosition.rotation);
        target.SetActive(true);
        RandomLaunchPower = Random.Range(0.5f, 0.9f);
        target.GetComponent<Rigidbody>().AddForce(transform.up * RandomLaunchPower, ForceMode.Impulse);
        StartCoroutine("CloseLid");
    }

    IEnumerator CloseLid()
    {
        yield return new WaitForSeconds(3f);
        isMoving = true;
    }
}
