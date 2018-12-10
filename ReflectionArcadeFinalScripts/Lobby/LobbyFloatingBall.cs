using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyFloatingBall : MonoBehaviour
{
    public float Bottom;
    public float Top;
    private bool floatingUp;
    public GameObject ball;
    public float floatSpeed;
    private int randomStartingDirection;

	// Use this for initialization
	void Start ()
    {
        floatSpeed = Random.Range(0.05f, 0.15f);
        randomStartingDirection = Random.Range(0, 1);
        if (randomStartingDirection == 0)
        {
            floatingUp = false;
        }
        else
        {
            floatingUp = true;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (floatingUp)
        {
            if (ball.transform.position.y < Top)
            {
                ball.transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
            }
            else
            {
                floatSpeed = Random.Range(0.05f, 0.15f);
                floatingUp = false;
            }
        }
        else if (!floatingUp)
        {
            if (ball.transform.position.y > Bottom)
            {
                ball.transform.Translate(Vector3.up * floatSpeed * -1 * Time.deltaTime);
            }
            else
            {
                floatSpeed = Random.Range(0.05f, 0.15f);
                floatingUp = true;
            }
        }
	}
}
