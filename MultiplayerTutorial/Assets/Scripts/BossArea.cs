using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MonoBehaviour
{
    public GameObject player;

    DataController Controller;

	// Use this for initialization
	void Start ()
    {
        Controller = FindObjectOfType<DataController>();

        // Player positioning

        if (Controller.PortalDestination == "PortalToBossAreaFromTown")
        {
            player.transform.position = new Vector3(145, 1.75f, 3);
            player.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
