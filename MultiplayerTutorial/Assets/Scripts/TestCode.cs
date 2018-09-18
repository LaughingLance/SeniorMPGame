using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public GameObject SampleCube;
    public GameObject TestBerry;

    private float BushPositionX;
    private float BushPositionY;
    private float BushPositionZ;

    private float BerryPositionX;
    private float BerryPositionY;
    private float BerryPositionZ;

    private float BushScaleX;
    private float BushScaleY;
    private float BushScaleZ;

    private bool BerryMoved = false;
    private int RandomSide;

	void Start ()
    {
        BushPositionX = SampleCube.transform.position.x;
        BushPositionY = SampleCube.transform.position.y;
        BushPositionZ = SampleCube.transform.position.z;
        BushScaleX = SampleCube.transform.localScale.x;
        BushScaleY = SampleCube.transform.localScale.y;
        BushScaleZ = SampleCube.transform.localScale.z;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!BerryMoved)
        {
            StartCoroutine("MoveTheBerry");
            BerryMoved = true;
        }

	}

    IEnumerator MoveTheBerry()
    {
        yield return new WaitForSeconds(1f);
        MoveBerry();
    }

    void MoveBerry()
    {
        RandomSide = Random.Range(1, 6);
        switch (RandomSide)
        {
            case 1: // Top
                BerryPositionX = Random.Range(BushPositionX - (BushScaleX / 2f), BushPositionX + (BushScaleX / 2f));
                BerryPositionY = BushPositionY + (BushScaleY * 0.6f);
                BerryPositionZ = Random.Range(BushPositionZ - (BushScaleZ / 2f), BushPositionZ + (BushScaleZ / 2f));
                TestBerry.transform.position = new Vector3(BerryPositionX, BerryPositionY, BerryPositionZ);
                BerryMoved = false;
                break;
            case 2: // North
                BerryPositionX = BushPositionX - (BushScaleX * 0.6f);
                BerryPositionY = Random.Range(BushPositionY - (BushScaleY / 2f), BushPositionY + (BushScaleY / 2f));
                BerryPositionZ = Random.Range(BushPositionZ - (BushScaleZ / 2f), BushPositionZ + (BushScaleZ / 2f));
                TestBerry.transform.position = new Vector3(BerryPositionX, BerryPositionY, BerryPositionZ);
                BerryMoved = false;
                break;
            case 3: // East
                BerryPositionX = Random.Range(BushPositionX - (BushScaleX / 2f), BushPositionX + (BushScaleX / 2f));
                BerryPositionY = Random.Range(BushPositionY - (BushScaleY / 2f), BushPositionY + (BushScaleY / 2f));
                BerryPositionZ = BushPositionZ + (BushScaleZ * 0.6f);
                TestBerry.transform.position = new Vector3(BerryPositionX, BerryPositionY, BerryPositionZ);
                BerryMoved = false;
                break;
            case 4: // South
                BerryPositionX = BushPositionX + (BushScaleX * 0.6f);
                BerryPositionY = Random.Range(BushPositionY - (BushScaleY / 2f), BushPositionY + (BushScaleY / 2f));
                BerryPositionZ = Random.Range(BushPositionZ - (BushScaleZ / 2f), BushPositionZ + (BushScaleZ / 2f));
                TestBerry.transform.position = new Vector3(BerryPositionX, BerryPositionY, BerryPositionZ);
                BerryMoved = false;
                break;
            case 5: // West
                BerryPositionX = Random.Range(BushPositionX - (BushScaleX / 2f), BushPositionX + (BushScaleX / 2f));
                BerryPositionY = Random.Range(BushPositionY - (BushScaleY / 2f), BushPositionY + (BushScaleY / 2f));
                BerryPositionZ = BushPositionZ - (BushScaleZ * 0.6f);
                TestBerry.transform.position = new Vector3(BerryPositionX, BerryPositionY, BerryPositionZ);
                BerryMoved = false;
                break;
            case 6: // Pick again
                MoveTheBerry();
                break;
        }
    }
}
