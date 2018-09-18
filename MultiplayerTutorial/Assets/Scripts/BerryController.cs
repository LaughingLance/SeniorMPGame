using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BerryController : NetworkBehaviour
{
    public List<GameObject> Berries = new List<GameObject>();
    public GameObject[] BerryBushes;
    public GameObject BerryPrefab;
    public int MinimumBerries;
    public int MaximumBerries;

    private GameObject Berry;
    private GameObject BerryBush;

    private float BushPositionX;
    private float BushPositionY;
    private float BushPositionZ;

    private float BerryPositionX;
    private float BerryPositionY;
    private float BerryPositionZ;

    private float BushScaleX;
    private float BushScaleY;
    private float BushScaleZ;

    private int RandomSide;
    private int RandomBush;
    private float RandomPauseTime;

    private bool PlaceBerries = false;
    private bool PlacingABerry = false;

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < MaximumBerries; i++)
        {
            FindABush();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!PlaceBerries)
        {
            if (Berries.Count < MinimumBerries)
            {
                PlaceBerries = true;
            }
        }
        else  // Time to refill the berries
        {
            if (Berries.Count < MaximumBerries)
            {
                if (!PlacingABerry)
                {
                    PlacingABerry = true;
                    RandomPauseTime = Random.Range(1f, 3f);
                    StartCoroutine("BerryPlacingDelay");
                }
            }
            else
            {
                PlaceBerries = false;
            }
        }
	}

    IEnumerator BerryPlacingDelay()
    {
        yield return new WaitForSeconds(RandomPauseTime);
        FindABush();
    }

    void FindABush()
    {
        RandomBush = Random.Range(1, BerryBushes.Length);
        BerryBush = BerryBushes[RandomBush];
        BushPositionX = BerryBush.transform.position.x;
        BushPositionY = BerryBush.transform.position.y;
        BushPositionZ = BerryBush.transform.position.z;
        BushScaleX = BerryBush.transform.localScale.x;
        BushScaleY = BerryBush.transform.localScale.y;
        BushScaleZ = BerryBush.transform.localScale.z;
        CreateBerry();
    }

    void CreateBerry()
    {
        Berry = Instantiate(BerryPrefab) as GameObject;
        CmdPlaceBerry();
    }

    [Command]
    void CmdPlaceBerry()
    {
        RandomSide = Random.Range(1, 6);
        switch (RandomSide)
        {
            case 1: // Top
                BerryPositionX = Random.Range(BushPositionX - (BushScaleX / 2f), BushPositionX + (BushScaleX / 2f));
                BerryPositionY = BushPositionY + (BushScaleY * 0.5f + 0.075f);
                BerryPositionZ = Random.Range(BushPositionZ - (BushScaleZ / 2f), BushPositionZ + (BushScaleZ / 2f));
                Berry.transform.position = new Vector3(BerryPositionX, BerryPositionY, BerryPositionZ);
                break;
            case 2: // North
                BerryPositionX = BushPositionX - (BushScaleX * 0.5f + 0.075f);
                BerryPositionY = Random.Range(BushPositionY - (BushScaleY / 2f), BushPositionY + (BushScaleY / 2f));
                BerryPositionZ = Random.Range(BushPositionZ - (BushScaleZ / 2f), BushPositionZ + (BushScaleZ / 2f));
                Berry.transform.position = new Vector3(BerryPositionX, BerryPositionY, BerryPositionZ);
                break;
            case 3: // East
                BerryPositionX = Random.Range(BushPositionX - (BushScaleX / 2f), BushPositionX + (BushScaleX / 2f));
                BerryPositionY = Random.Range(BushPositionY - (BushScaleY / 2f), BushPositionY + (BushScaleY / 2f));
                BerryPositionZ = BushPositionZ + (BushScaleZ * 0.5f + 0.075f);
                Berry.transform.position = new Vector3(BerryPositionX, BerryPositionY, BerryPositionZ);
                break;
            case 4: // South
                BerryPositionX = BushPositionX + (BushScaleX * 0.5f + 0.075f);
                BerryPositionY = Random.Range(BushPositionY - (BushScaleY / 2f), BushPositionY + (BushScaleY / 2f));
                BerryPositionZ = Random.Range(BushPositionZ - (BushScaleZ / 2f), BushPositionZ + (BushScaleZ / 2f));
                Berry.transform.position = new Vector3(BerryPositionX, BerryPositionY, BerryPositionZ);
                break;
            case 5: // West
                BerryPositionX = Random.Range(BushPositionX - (BushScaleX / 2f), BushPositionX + (BushScaleX / 2f));
                BerryPositionY = Random.Range(BushPositionY - (BushScaleY / 2f), BushPositionY + (BushScaleY / 2f));
                BerryPositionZ = BushPositionZ - (BushScaleZ * 0.5f + 0.075f);
                Berry.transform.position = new Vector3(BerryPositionX, BerryPositionY, BerryPositionZ);
                break;
            case 6: // Pick again
                CmdPlaceBerry();
                break;
        }
        //Berry.SetActive(true);
        NetworkServer.Spawn(Berry);
        Berries.Add(Berry);
        PlacingABerry = false;
    }
}
