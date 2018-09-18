using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class EnemyBasicController : NetworkBehaviour
{
    // Basic Enemy Combining Variables

    // Player Lists
    private List<GameObject> players = new List<GameObject>();
    private List<GameObject> playersWithinRange = new List<GameObject>();

    // Basic Enemy Movement Variables
    private bool AtLocation = true;
    private Vector3 EnemyTargetPosition;
    private Vector3 CurrentEnemyPosition;
    private float RandomXPosition;
    private float RandomZPosition;
    public float navigationUpdate;
    private float navigationTime = 0;
    private bool Moving = true;
    private bool Fleeing = false;
    private float FleeX;
    private float FleeZ;


    // Player and other enemy check variables
    public float EnemyPlayerUpdate;
    private float EnemyPlayerTime = 0;
    private float EnemyToPlayerDistance; // the distance between a player and the enemy
    private float EnemyToEnemyDistance; // the distance between the enemy and the other basic enemies
    public GameObject ClosestPlayer;
    private GameObject ClosestEnemy;


    // shooting variables
    public GameObject BulletPrefab;
    public GameObject Gun;
    public Transform LaunchPosition;
    public int BulletSpeed;
    public int ShotIntervalMinimum;
    public int ShotIntervalMaximum;
    public int ShotInterval;
    private int ShotCounter;
    public bool Attack = false;


    private Vector3 directionToTarget;
    private Vector3 currentPosition;
    private Vector3 targetPosition;
    private float closestDistanceSquare;
    private float dSquareToTarget;

    private NavMeshAgent agent;
    private NavMeshPath path;
    

    EnemyController Enemies;

    EnemyBasicController BasicController;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        Enemies = FindObjectOfType<EnemyController>();
        ShotInterval = Random.Range(ShotIntervalMinimum, ShotIntervalMaximum);

        foreach (GameObject playerObj in GameObject.FindGameObjectsWithTag("Player"))
        {
            players.Add(playerObj);
        }
        EnemyPlayerTime = 1;
    }

    // Update is called once per frame
    void Update ()
    {
        EnemyPlayerTime += Time.deltaTime;

        if (EnemyPlayerTime > EnemyPlayerUpdate)
        {
            // Checks to see if there is a new player in the area
            foreach (GameObject playerObj in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (players.Contains(playerObj))
                {
                    
                }
                else
                {
                    players.Add(playerObj);
                }
            }            

            // Checks to see if there is a player the enemy should be fleeing from
            if (!Fleeing)
            {
                if (players.Count != 0)
                {
                    closestDistanceSquare = Mathf.Infinity;
                    currentPosition = transform.position;

                    foreach (GameObject potentialTarget in players)
                    {
                        directionToTarget = potentialTarget.transform.position - currentPosition;
                        dSquareToTarget = directionToTarget.sqrMagnitude;
                        if (dSquareToTarget < closestDistanceSquare)
                        {
                            closestDistanceSquare = dSquareToTarget;
                            ClosestPlayer = potentialTarget;
                        }
                    }

                    EnemyToPlayerDistance = Vector3.Distance(transform.position, ClosestPlayer.transform.position);

                    if (EnemyToPlayerDistance <= 15f)
                    {
                        StopCoroutine("LocationIdle");
                        agent.speed = 7f;
                        Fleeing = true;
                        AtLocation = true;
                    }
                }
            }
            else
            // if the basic enemy is fleeing then there are two choices...
            // Option 1: Stop fleeing if the player is now far enough away
            // Option 2: If there is another basic enemy close enough, then stop moving and attack
            {
                EnemyToPlayerDistance = Vector3.Distance(transform.position, ClosestPlayer.transform.position);
                if (EnemyToPlayerDistance > 25f)
                {
                    agent.speed = 3.5f;
                    Fleeing = false;
                    Attack = false;
                    Moving = true;
                    AtLocation = true;
                }
                else if (EnemyToPlayerDistance < 5f)
                {
                    agent.speed = 0f;
                    Moving = false;
                    Attack = true;
                }
                else
                // Option 2 is checked first
                // Checks to see if there is another enemy within range ... this causes the enemy to stop moving and target the player
                // but only if there already is a player within range and the enemy is fleeing
                {
                    if (Enemies.BasicEnemies.Count > 0)
                    {
                        foreach (GameObject enemyObj in Enemies.BasicEnemies)
                        {
                            EnemyToEnemyDistance = Vector3.Distance(transform.position, enemyObj.transform.position);
                            if (EnemyToEnemyDistance < 10f && EnemyToEnemyDistance > 2f)
                            {
                                Moving = false;
                                Attack = true;
                                agent.speed = 0f;
                                break;
                            }
                        }
                    }
                }                
            }

            // This checks to see if the closest nearby enemy is attacking a player. If so then this enemy joins in on the attack
            if (!Attack)
            {
                if (Enemies.BasicEnemies.Count > 0)
                {
                    closestDistanceSquare = Mathf.Infinity;
                    currentPosition = transform.position;

                    foreach (GameObject potentialFriendly in Enemies.BasicEnemies)
                    {
                        directionToTarget = potentialFriendly.transform.position - currentPosition;
                        dSquareToTarget = directionToTarget.sqrMagnitude;
                        if (dSquareToTarget < closestDistanceSquare && dSquareToTarget > 1)
                        {
                            closestDistanceSquare = dSquareToTarget;
                            ClosestEnemy = potentialFriendly;
                        }
                    }

                    EnemyToEnemyDistance = Vector3.Distance(transform.position, ClosestEnemy.transform.position);

                    if (EnemyToEnemyDistance <= 10f)
                    {
                        BasicController = ClosestEnemy.GetComponent<EnemyBasicController>();
                        if (BasicController.Attack == true)
                        {
                            ClosestPlayer = BasicController.ClosestPlayer;
                            Moving = false;
                            Attack = true;
                            agent.speed = 0f;
                        }
                    }
                }
            }
            else
            {
                EnemyToPlayerDistance = Vector3.Distance(transform.position, ClosestPlayer.transform.position);
                if (EnemyToPlayerDistance > 25f)
                {
                    agent.speed = 3.5f;
                    Fleeing = false;
                    Attack = false;
                    Moving = true;
                    AtLocation = true;
                }
            }

            EnemyPlayerTime = 0;
        }

        if (Moving && Fleeing)
        {
            // Checking to see if the enemy is at the edge of the NavMesh while being chased by a player
            // If the enemy is close to the edge of the NavMesh, then it goes on the offense and attacks
            NavMeshHit FleeingHit;
            if (NavMesh.FindClosestEdge(transform.position, out FleeingHit, NavMesh.AllAreas))
            {
                if (FleeingHit.distance < 2)
                {
                    Moving = false;
                    Attack = true;
                }
            }
            
            if (AtLocation)
            {
                CalculateFleeingDestination();
            }
            else
            {
                if (Mathf.Abs(transform.position.x - EnemyTargetPosition.x) < 1.5f && Mathf.Abs(transform.position.z - EnemyTargetPosition.z) < 1.5f)
                {
                    AtLocation = true;
                }
                else
                {
                    navigationTime += Time.deltaTime;
                    if (navigationTime > navigationUpdate)
                    {
                        agent.destination = EnemyTargetPosition;
                        navigationTime = 0;
                    }
                }
            }
        }

        if (Moving && !Fleeing)
        {
            // Checking to see if the enemy is at the edge of the NavMesh and if so make it choose a new direction
            // This checks the distance to the nearest edge of the complete NavMesh
            NavMeshHit hit;
            if (NavMesh.FindClosestEdge(transform.position, out hit, NavMesh.AllAreas))
            {
                if (hit.distance <= 2)
                {
                    StartCoroutine("LocationIdle");
                }
            }
            
            // Enemy Movement if player isn't close
            if (AtLocation)
            {
                StartCoroutine("LocationIdle");
            }
            else
            {
                if (Mathf.Abs(transform.position.x - EnemyTargetPosition.x) < 0.5f && Mathf.Abs(transform.position.z - EnemyTargetPosition.z) < 0.5f)
                {
                    AtLocation = true;
                }
                else
                {
                    navigationTime += Time.deltaTime;
                    if (navigationTime > navigationUpdate)
                    {
                        agent.destination = EnemyTargetPosition;
                        navigationTime = 0;
                    }
                }
            }
        }

        if (Attack)
        {
            agent.speed = 0f;

            targetPosition = new Vector3(ClosestPlayer.transform.position.x, transform.position.y, ClosestPlayer.transform.position.z);
            transform.LookAt(targetPosition);

            if (ShotCounter < ShotInterval)
            {
                ShotCounter++;
            }
            else
            {
                CmdShootGun(BulletPrefab);
                ShotInterval = Random.Range(ShotIntervalMinimum, ShotIntervalMaximum);
                ShotCounter = 0;
            }
        }
    }

    [Command]
    void CmdShootGun(GameObject bullet)
    {
        GameObject BulletObj = Instantiate(bullet) as GameObject;

        int TargetRandomNumber = Random.Range(1, 99);

        if (TargetRandomNumber < 34)
        {
            Gun.transform.LookAt(ClosestPlayer.transform.Find("TargetOne"));
        }
        else if (TargetRandomNumber >= 34 && TargetRandomNumber < 67)
        {
            Gun.transform.LookAt(ClosestPlayer.transform.Find("TargetTwo"));
        }
        else if (TargetRandomNumber >= 67)
        {
            Gun.transform.LookAt(ClosestPlayer.transform.Find("TargetThree"));
        }


        //      BulletObj.SetActive(true);
        NetworkServer.Spawn(BulletObj);
        BulletObj.transform.position = LaunchPosition.position;
        BulletObj.transform.rotation = LaunchPosition.rotation;

        BulletObj.GetComponent<Rigidbody>().AddForce(LaunchPosition.up * BulletSpeed * 1f, ForceMode.Impulse);
    }

    void CalculateMovingDestination()
    {
        CurrentEnemyPosition = transform.position;
        RandomXPosition = Random.Range(CurrentEnemyPosition.x - 20, CurrentEnemyPosition.x + 20);
        RandomZPosition = Random.Range(CurrentEnemyPosition.z - 20, CurrentEnemyPosition.z + 20);
        EnemyTargetPosition = new Vector3(RandomXPosition, CurrentEnemyPosition.y, RandomZPosition);

        agent.CalculatePath(EnemyTargetPosition, path);
        if (path.status == NavMeshPathStatus.PathPartial) // checks to see if path is unreachable and if so then 
        {
            CalculateMovingDestination();
        }
        else
        {
            AtLocation = false;
        }
    }

    void CalculateFleeingDestination()
    {
        CurrentEnemyPosition = transform.position;
        FleeX = transform.position.x - ClosestPlayer.transform.position.x;
        FleeZ = transform.position.z - ClosestPlayer.transform.position.z;

        RandomXPosition = Random.Range(CurrentEnemyPosition.x, CurrentEnemyPosition.x + FleeX);
        RandomZPosition = Random.Range(CurrentEnemyPosition.z, CurrentEnemyPosition.z + FleeZ);
        EnemyTargetPosition = new Vector3(RandomXPosition, CurrentEnemyPosition.y, RandomZPosition);

        agent.CalculatePath(EnemyTargetPosition, path);
        if (path.status == NavMeshPathStatus.PathPartial)
        {
            CalculateFleeingDestination();
        }
        else
        {
            AtLocation = false;
        }
    }

    IEnumerator LocationIdle()
    {
        yield return new WaitForSeconds(2f);
        CalculateMovingDestination();
    }
}