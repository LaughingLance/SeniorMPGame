using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedInventoryController : MonoBehaviour
{
    DataController Controller;

    public GameObject HeadEjector;
    public GameObject ChestEjector;
    public GameObject LegEjector;
    public GameObject ShieldEjector;

    private GameObject RejectedItem;
    private GameObject RejectDuplicate;

    private GameObject CurrentHeadItem;
    private GameObject CurrentChestItem;
    private GameObject CurrentLegItem;
    private GameObject CurrentShieldItem;

    private bool EjectHead = false;
    private bool LowerHead = false;
    private bool EjectChest = false;
    private bool LowerChest = false;
    private bool EjectLeg = false;
    private bool LowerLeg = false;
    private bool EjectShield = false;
    private bool LowerShield = false;
    private bool CollisionHappened = false;

    public GameObject BlueHelmPrefab;
    public GameObject GreenHelmPrefab;
    public GameObject WhiteHelmPrefab;

    public GameObject BlueChestPrefab;
    public GameObject GreenChestPrefab;
    public GameObject WhiteChestPrefab;

    public GameObject BlueLegsPrefab;
    public GameObject GreenLegsPrefab;
    public GameObject WhiteLegsPrefab;

    public GameObject BlueShieldPrefab;
    public GameObject GreenShieldPrefab;
    public GameObject WhiteShieldPrefab;

    private Vector3 HelmStartingPosition = new Vector3(4.5f, 4f, 0f);
    private Vector3 ChestStartingPosition = new Vector3(1.5f, 4f, 0f);
    private Vector3 LegStartingPosition = new Vector3(-1.5f, 4f, 0f);
    private Vector3 ShieldStartingPosition = new Vector3(-4.5f, 4f, 0f);

    private GameObject HeadObj;
    private GameObject ChestObj;
    private GameObject LegObj;
    private GameObject ShieldObj;

	// Use this for initialization
	void Start ()
    {
        Controller = FindObjectOfType<DataController>();

        if (Controller.HeadSlot != "")
        {
            switch (Controller.HeadSlot)
            {
                case "HeadWhite":
                    HeadObj = Instantiate(WhiteHelmPrefab) as GameObject;
                    HeadObj.SetActive(true);
                    HeadObj.transform.position = HelmStartingPosition;
                    break;
                case "HeadGreen":
                    HeadObj = Instantiate(GreenHelmPrefab) as GameObject;
                    HeadObj.SetActive(true);
                    HeadObj.transform.position = HelmStartingPosition;
                    break;
                case "HeadBlue":
                    HeadObj = Instantiate(BlueHelmPrefab) as GameObject;
                    HeadObj.SetActive(true);
                    HeadObj.transform.position = HelmStartingPosition;
                    break;
            }
        }

        if (Controller.ChestSlot != "")
        {
            switch (Controller.ChestSlot)
            {
                case "ChestWhite":
                    ChestObj = Instantiate(WhiteChestPrefab) as GameObject;
                    ChestObj.SetActive(true);
                    ChestObj.transform.position = ChestStartingPosition;
                    break;
                case "ChestGreen":
                    ChestObj = Instantiate(GreenChestPrefab) as GameObject;
                    ChestObj.SetActive(true);
                    ChestObj.transform.position = ChestStartingPosition;
                    break;
                case "ChestBlue":
                    ChestObj = Instantiate(BlueChestPrefab) as GameObject;
                    ChestObj.SetActive(true);
                    ChestObj.transform.position = ChestStartingPosition;
                    break;
            }
        }

        if (Controller.LegSlot != "")
        {
            switch (Controller.LegSlot)
            {
                case "LegWhite":
                    LegObj = Instantiate(WhiteLegsPrefab) as GameObject;
                    LegObj.SetActive(true);
                    LegObj.transform.position = LegStartingPosition;
                    break;
                case "LegGreen":
                    LegObj = Instantiate(GreenLegsPrefab) as GameObject;
                    LegObj.SetActive(true);
                    LegObj.transform.position = LegStartingPosition;
                    break;
                case "LegBlue":
                    LegObj = Instantiate(BlueLegsPrefab) as GameObject;
                    LegObj.SetActive(true);
                    LegObj.transform.position = LegStartingPosition;
                    break;
            }
        }

        if (Controller.ShieldSlot != "")
        {
            switch (Controller.ShieldSlot)
            {
                case "ShieldWhite":
                    ShieldObj = Instantiate(WhiteShieldPrefab) as GameObject;
                    ShieldObj.SetActive(true);
                    ShieldObj.transform.position = ShieldStartingPosition;
                    break;
                case "ShieldGreen":
                    ShieldObj = Instantiate(GreenShieldPrefab) as GameObject;
                    ShieldObj.SetActive(true);
                    ShieldObj.transform.position = ShieldStartingPosition;
                    break;
                case "ShieldBlue":
                    ShieldObj = Instantiate(BlueShieldPrefab) as GameObject;
                    ShieldObj.SetActive(true);
                    ShieldObj.transform.position = ShieldStartingPosition;
                    break;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Head Ejector
        if (EjectHead)
        {
            if (HeadEjector.transform.eulerAngles.x <= 75)
            {
                HeadEjector.transform.Rotate(Vector3.right * Time.deltaTime * 75f);
            }
            else
            {
                EjectHead = false;
                LowerHead = true;
            }
        }
        if (LowerHead)
        {
            if (HeadEjector.transform.eulerAngles.x > 0.2f )
            {
                HeadEjector.transform.Rotate(Vector3.right * Time.deltaTime * -12.5f);
            }
            else
            {
                Controller.HeadSlot = "";
                CurrentHeadItem = null;
                CollisionHappened = false;
                LowerHead = false;
            }
        }
        // Chest Ejector
        if (EjectChest)
        {
            if (ChestEjector.transform.eulerAngles.x <= 75)
            {
                ChestEjector.transform.Rotate(Vector3.right * Time.deltaTime * 75f);
            }
            else
            {
                EjectChest = false;
                LowerChest = true;
            }
        }
        if (LowerChest)
        {
            if (ChestEjector.transform.eulerAngles.x > 0.2f)
            {
                ChestEjector.transform.Rotate(Vector3.right * Time.deltaTime * -12.5f);
            }
            else
            {
                Controller.ChestSlot = "";
                CurrentChestItem = null;
                CollisionHappened = false;
                LowerChest = false;
            }
        }
        // Leg Ejector
        if (EjectLeg)
        {
            if (LegEjector.transform.eulerAngles.x <= 75)
            {
                LegEjector.transform.Rotate(Vector3.right * Time.deltaTime * 75f);
            }
            else
            {
                EjectLeg = false;
                LowerLeg = true;
            }
        }
        if (LowerLeg)
        {
            if (LegEjector.transform.eulerAngles.x > 0.2f)
            {
                LegEjector.transform.Rotate(Vector3.right * Time.deltaTime * -12.5f);
            }
            else
            {
                Controller.LegSlot = "";
                CurrentLegItem = null;
                CollisionHappened = false;
                LowerLeg = false;
            }
        }
        // Shield Ejector
        if (EjectShield)
        {
            if (ShieldEjector.transform.eulerAngles.x <= 75)
            {
                ShieldEjector.transform.Rotate(Vector3.right * Time.deltaTime * 75f);
            }
            else
            {
                EjectShield = false;
                LowerShield = true;
            }
        }
        if (LowerShield)
        {
            if (ShieldEjector.transform.eulerAngles.x > 0.2f)
            {
                ShieldEjector.transform.Rotate(Vector3.right * Time.deltaTime * -12.5f);
            }
            else
            {
                Controller.ShieldSlot = "";
                CurrentShieldItem = null;
                CollisionHappened = false;
                LowerShield = false;
            }
        }
    }

    private void OnCollisionEnter(Collision colEnter)
    {
        if (!CollisionHappened)
        {
            switch (colEnter.gameObject.tag)
            {
                case "Head":
                    CollisionHappened = true;

                    if (CurrentHeadItem == null)
                    {
                        if (gameObject.name == "HeadPedestal")
                        {
                            Controller.HeadSlot = colEnter.gameObject.name;
                            CurrentHeadItem = colEnter.gameObject;
                            StartCoroutine("ItemPlacementPause");
                            break;
                        }
                        else
                        {
                            if (gameObject.name == "ChestPedestal")
                            {
                                StartCoroutine("ClearChestSlot");
                            }

                            if (gameObject.name == "LegPedestal")
                            {
                                StartCoroutine("ClearLegSlot");
                            }

                            if (gameObject.name == "ShieldPedestal")
                            {
                                StartCoroutine("ClearShieldSlot");
                            }

                            break;
                        }
                    }
                    else
                    {
                        StartCoroutine("ClearHeadSlot");
                        break;
                    }
                case "Chest":
                    CollisionHappened = true;
                    if (CurrentChestItem == null)
                    {
                        if (gameObject.name == "ChestPedestal")
                        {
                            Controller.ChestSlot = colEnter.gameObject.name;
                            CurrentChestItem = colEnter.gameObject;
                            StartCoroutine("ItemPlacementPause");
                            break;
                        }
                        else
                        {
                            if (gameObject.name == "HeadPedestal")
                            {
                                StartCoroutine("ClearHeadSlot");
                            }

                            if (gameObject.name == "LegPedestal")
                            {
                                StartCoroutine("ClearLegSlot");
                            }

                            if (gameObject.name == "ShieldPedestal")
                            {
                                StartCoroutine("ClearShieldSlot");
                            }

                            break;
                        }
                    }
                    else
                    {
                        StartCoroutine("ClearChestSlot");
                        break;
                    }                    
                case "Leg":
                    CollisionHappened = true;

                    if (CurrentLegItem == null)
                    {
                        if (gameObject.name == "LegPedestal")
                        {
                            Controller.LegSlot = colEnter.gameObject.name;
                            CurrentLegItem = colEnter.gameObject;
                            StartCoroutine("ItemPlacementPause");
                            break;
                        }
                        else
                        {
                            if (gameObject.name == "HeadPedestal")
                            {
                                StartCoroutine("ClearHeadSlot");
                            }

                            if (gameObject.name == "ChestPedestal")
                            {
                                StartCoroutine("ClearChestSlot");
                            }

                            if (gameObject.name == "ShieldPedestal")
                            {
                                StartCoroutine("ClearShieldSlot");
                            }

                            break;
                        }
                    }
                    else
                    {
                        StartCoroutine("ClearLegSlot");
                        break;
                    }
                case "Shield":
                    CollisionHappened = true;

                    if (CurrentShieldItem == null)
                    {
                        if (gameObject.name == "ShieldPedestal")
                        {
                            Controller.ShieldSlot = colEnter.gameObject.name;
                            CurrentShieldItem = colEnter.gameObject;
                            StartCoroutine("ItemPlacementPause");
                            break;
                        }
                        else
                        {
                            if (gameObject.name == "HeadPedestal")
                            {
                                StartCoroutine("ClearHeadSlot");
                            }

                            if (gameObject.name == "ChestPedestal")
                            {
                                StartCoroutine("ClearChestSlot");
                            }

                            if (gameObject.name == "LegPedestal")
                            {
                                StartCoroutine("ClearLegSlot");
                            }

                            break;
                        }
                    }
                    else
                    {
                        StartCoroutine("ClearShieldSlot");
                        break;
                    }            
            }
        }        
    }

    IEnumerator ItemPlacementPause()
    {
        yield return new WaitForSeconds(0.05f);
        CollisionHappened = false;

    }

    IEnumerator ClearHeadSlot()
    {
        yield return new WaitForSeconds(0.5f);
        EjectHead = true;
    }

    IEnumerator ClearChestSlot()
    {
        yield return new WaitForSeconds(0.51f);
        EjectChest = true;
    }

    IEnumerator ClearLegSlot()
    {
        yield return new WaitForSeconds(0.51f);
        EjectLeg = true;
    }

    IEnumerator ClearShieldSlot()
    {
        yield return new WaitForSeconds(0.51f);
        EjectShield = true;
    }
}
