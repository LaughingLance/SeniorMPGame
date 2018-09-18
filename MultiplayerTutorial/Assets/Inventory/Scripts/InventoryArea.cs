using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryArea : MonoBehaviour
{
    public GameObject player;

    DataController Controller;

	// Use this for initialization
	void Start ()
    {
        Controller = FindObjectOfType<DataController>();

        // Player Positioning

        if (Controller.PortalDestination == "PortalToInventoryFromTown")
        {
            player.transform.position = new Vector3(0, 1.75f, 8);
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
	}

}
