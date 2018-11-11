using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBallController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * 5, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
