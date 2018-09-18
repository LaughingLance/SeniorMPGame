using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyController : NetworkBehaviour
{
    // Basic Enemy Variables
    public List<GameObject> BasicEnemies = new List<GameObject>();
    public GameObject[] BasicSpawnPoints;
    public GameObject BasicEnemy;
    private Vector3 BasicSpawnPosition;

    // Medium Enemy Variables
    public List<GameObject> ModerateEnemies = new List<GameObject>();
    public GameObject[] ModerateSpawnPoints;
    public GameObject ModerateEnemy;
    private Vector3 ModerateSpawnPosition;
    
    // Advanced Enemy Variables
    public List<GameObject> AdvancedEnemies = new List<GameObject>();
    public GameObject[] AdvancedSpawnPoints;
    public GameObject AdvancedEnemy;
    private Vector3 AdvancedSpawnPosition;

    // Boss Enemy Variables
    public List<GameObject> BossEnemies = new List<GameObject>();
    public GameObject[] BossSpawnPoints;
    public GameObject BossEnemy;
    private Vector3 BossSpawnPosition;


	// Use this for initialization
	void Start ()
    {
        // Spawn initial enemies - Basic
        foreach (GameObject basicSpawn in BasicSpawnPoints)
        {
            BasicSpawnPosition = basicSpawn.transform.position;
            GameObject BasicEnemySpawn = Instantiate(BasicEnemy) as GameObject;
            //BasicEnemySpawn.SetActive(true);
            NetworkServer.Spawn(BasicEnemySpawn);
            BasicEnemySpawn.transform.position = BasicSpawnPosition;
            BasicEnemies.Add(BasicEnemySpawn);
        }

        // Moderate
        foreach (GameObject moderateSpawn in ModerateSpawnPoints)
        {
            ModerateSpawnPosition = moderateSpawn.transform.position;
            GameObject ModerateEnemySpawn = Instantiate(ModerateEnemy) as GameObject;
            //    ModerateEnemySpawn.SetActive(true);
            NetworkServer.Spawn(ModerateEnemySpawn);
            ModerateEnemySpawn.transform.position = ModerateSpawnPosition;
            ModerateEnemies.Add(ModerateEnemySpawn);
        }

        // Advanced
        foreach (GameObject advancedSpawn in AdvancedSpawnPoints)
        {
            AdvancedSpawnPosition = advancedSpawn.transform.position;
            GameObject AdvancedEnemySpawn = Instantiate(AdvancedEnemy) as GameObject;
            //      AdvancedEnemySpawn.SetActive(true);
            NetworkServer.Spawn(AdvancedEnemySpawn);
            AdvancedEnemySpawn.transform.position = AdvancedSpawnPosition;
            AdvancedEnemies.Add(AdvancedEnemySpawn);
        }

        // Boss
        foreach (GameObject bossSpawn in BossSpawnPoints)
        {
            BossSpawnPosition = bossSpawn.transform.position;
            GameObject BossEnemySpawn = Instantiate(BossEnemy) as GameObject;
            //       BossEnemySpawn.SetActive(true);
            NetworkServer.Spawn(BossEnemySpawn);
            BossEnemySpawn.transform.position = BossSpawnPosition;
            BossEnemies.Add(BossEnemySpawn);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
    
	}
}
