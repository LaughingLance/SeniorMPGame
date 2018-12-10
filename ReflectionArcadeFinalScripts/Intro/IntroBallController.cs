using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBallController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * 5, ForceMode.Impulse);
        StartCoroutine("DestroyBallTimer");
	}

    IEnumerator DestroyBallTimer()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

}
