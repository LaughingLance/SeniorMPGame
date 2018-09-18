using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryDestroy : MonoBehaviour
{
    public GameObject ThisBerry;
    private float BerryDestructionTimer;

    BerryController Controller;

	// Use this for initialization
	void Start ()
    {
        Controller = FindObjectOfType<BerryController>();

        BerryDestructionTimer = Random.Range(30f, 120f);
        StartCoroutine("DestroyBerry");
	}

    IEnumerator DestroyBerry()
    {
        yield return new WaitForSeconds(BerryDestructionTimer);
        Controller.Berries.Remove(ThisBerry);
        Destroy(ThisBerry);
    }
}
