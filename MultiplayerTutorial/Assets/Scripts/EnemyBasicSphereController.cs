using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyBasicSphereController : NetworkBehaviour
{
    private Rigidbody RB;
    private bool SpawnedNewEnemy = false;
    public GameObject BasicEnemy;
    public GameObject RawEnemy;

    EnemyController Enemies;

	// Use this for initialization
	void Start ()
    {
        Enemies = FindObjectOfType<EnemyController>();
        RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        RB.isKinematic = true;
        if (!SpawnedNewEnemy)
        {
            GameObject MinionObj = Instantiate(BasicEnemy) as GameObject;
          //  MinionObj.SetActive(true);
            NetworkServer.Spawn(MinionObj);
            MinionObj.transform.position = transform.position;

            Enemies.BasicEnemies.Add(BasicEnemy);
            SpawnedNewEnemy = true;
        }
        
        Destroy(RawEnemy);
    }
}
