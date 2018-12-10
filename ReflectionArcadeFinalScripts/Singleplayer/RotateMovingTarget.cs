using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMovingTarget : MonoBehaviour
{
    private bool OkayToDestroy = false;
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.up * -180f * Time.deltaTime);

        if (transform.position.y > -1 && !OkayToDestroy)
        {
            OkayToDestroy = true;
        }
        if (transform.position.y < -1.7 && OkayToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
