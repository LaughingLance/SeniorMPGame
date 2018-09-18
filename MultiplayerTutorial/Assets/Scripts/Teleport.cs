using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    DataController Controller;

    private bool CollidedWithPortal = false;

    // Use this for initialization
    void Start()
    {
        Controller = FindObjectOfType<DataController>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!CollidedWithPortal)
        {
            switch (other.name)
            {
                case "PortalToTownFromBossArea":
                    Debug.Log("Collided with the Town Portal");
                    Controller.PortalDestination = "PortalToTownFromBossArea";
                    SceneManager.LoadScene("Main");
                    CollidedWithPortal = true;
                    break;
                case "PortalToBossAreaFromTown":
                    Debug.Log("Colliede with the Boss Portal");
                    Controller.PortalDestination = "PortalToBossAreaFromTown";
                    SceneManager.LoadScene("Boss Fight");
                    CollidedWithPortal = true;
                    break;
                case "PortalToTownFromInventory":
                    Controller.PortalDestination = "PortalToTownFromInventory";
                    SceneManager.LoadScene("Main");
                    CollidedWithPortal = true;
                    break;
                case "PortalToInventoryFromTown":
                    Controller.PortalDestination = "PortalToInventoryFromTown";
                    SceneManager.LoadScene("Inventory");
                    CollidedWithPortal = true;
                    break;
            }
        }
        CollidedWithPortal = false;
    }
}
