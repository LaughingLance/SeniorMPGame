using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StartingPositions : NetworkBehaviour
{
    DataController Controller;

    // Use this for initialization
    void Start()
    {
        Controller = FindObjectOfType<DataController>();
    }

    public override void OnStartLocalPlayer()
    {
       transform.position = new Vector3(0, 1.75f, 15);
       transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.PortalDestination == "PortalToInventoryFromTown")
        {
            transform.position = new Vector3(0, 1.75f, 6);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.GetChild(0).position = new Vector3(0, 1.75f, 6);
            transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
            Controller.PortalDestination = "";
            
        }

        if (Controller.PortalDestination == "PortalToTownFromInventory")
        {
            transform.position = new Vector3(2, 1.75f, -21);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.GetChild(0).position = new Vector3(2, 1.75f, -21);
            transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
            Controller.PortalDestination = "";
        }

        if (Controller.PortalDestination == "PortalToTownFromBossArea")
        {
            transform.position = new Vector3(-143, 1.75f, -5);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.GetChild(0).position = new Vector3(-143, 1.75f, -5);
            transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
            Controller.PortalDestination = "";
        }

        if (Controller.PortalDestination == "PortalToBossAreaFromTown")
        {
            transform.position = new Vector3(143, 1.75f, 3);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.GetChild(0).position = new Vector3(143, 1.75f, 3);
            transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
            Controller.PortalDestination = "";
        }
    }
}
