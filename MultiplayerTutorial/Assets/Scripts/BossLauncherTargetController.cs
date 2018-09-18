using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLauncherTargetController : MonoBehaviour
{
    public Transform Boss;
    public Transform LauncherTarget;

    private bool MovingLeft = true;
    private int MovingCounter;

	// Use this for initialization
	void Start ()
    {
        MovingCounter = 250;
	}
	
	// Update is called once per frame
	void Update ()
    {
        LauncherTarget.LookAt(Boss);

		if (MovingLeft)
        {
            if (MovingCounter <= 499)
            {
                MovingCounter++;
                LauncherTarget.transform.Translate(Vector3.right * Time.deltaTime * -10f);
            }
            else if (MovingCounter == 500)
            {
                MovingLeft = false;
            }
        }
        else // moving Right
        {
            if (MovingCounter >= 1)
            {
                MovingCounter--;
                LauncherTarget.transform.Translate(Vector3.right * Time.deltaTime * 10f);
            }
            else if (MovingCounter == 0)
            {
                MovingLeft = true;
            }
        }
	}
}
