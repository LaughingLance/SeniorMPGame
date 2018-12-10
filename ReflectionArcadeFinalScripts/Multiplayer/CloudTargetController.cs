using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CloudTargetController : NetworkBehaviour
{
    public GameObject CloudPrefab;

    public bool isTimeToMakeClouds;

	// Use this for initialization
	void Start ()
    {
        isTimeToMakeClouds = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isTimeToMakeClouds)
        {
            CmdLaunchCloudTarget();
            isTimeToMakeClouds = false;
            StartCoroutine("Pause");
        }
    }


    [Command]
    void CmdLaunchCloudTarget()
    {
        Vector3 RandomSpawnLocation = new Vector3(-15f, Random.Range(1f, 8f), Random.Range(10f, 35f));
        Quaternion RandomSpawnRotation = new Quaternion(0, 0, 0, 0);
        var cloud = (GameObject)Instantiate(CloudPrefab, RandomSpawnLocation, RandomSpawnRotation);
        NetworkServer.Spawn(cloud);
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 4f));
        isTimeToMakeClouds = true;
    }    
}
