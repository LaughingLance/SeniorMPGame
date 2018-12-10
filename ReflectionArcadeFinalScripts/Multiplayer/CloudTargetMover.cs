using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CloudTargetMover : NetworkBehaviour
{
    private Vector3 StartingPostion;
    private bool isMovingUp;
    private float TopYPosition;
    private float BottomYPosition;

	// Use this for initialization
	void Start ()
    {
        StartingPostion = transform.position;
        TopYPosition = StartingPostion.y + Random.Range(0.25f, 2f);
        BottomYPosition = StartingPostion.y - Random.Range(0.25f, 2f);
        int i = Random.Range(1, 100);
        if (i <= 50)
        {
            isMovingUp = false;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (transform.position.x > 25)
        {
            NetworkServer.Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.right * 1f * Time.deltaTime);

            if (isMovingUp)
            {
                if (transform.position.y < TopYPosition)
                {
                    transform.Translate(Vector3.up * 0.25f * Time.deltaTime);
                }
                else
                {
                    isMovingUp = false;
                }
            }
            else
            {
                if (transform.position.y > BottomYPosition)
                {
                    transform.Translate(Vector3.up * -0.25f * Time.deltaTime);
                }
                else
                {
                    isMovingUp = true;
                }
            }

        }
	}
}
