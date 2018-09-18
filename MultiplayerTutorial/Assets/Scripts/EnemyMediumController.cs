using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class EnemyMediumController : NetworkBehaviour
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


    // Player and other enemy check variables
    public float EnemyPlayerUpdate;
    private float EnemyPlayerTime = 0;
    private float EnemyToPlayerDistance; // the distance between a player and the enemy
    public GameObject ClosestPlayer;


    // shooting variables
    public GameObject BulletPrefab;
    public GameObject LeftGun;
    public GameObject RightGun;
    public Transform LaunchPositionLeft;
    public Transform LaunchPositionRight;
    public int BulletSpeed;
    public int ShotIntervalMinimum;
    public int ShotIntervalMaximum;
    public int ShotInterval;
    private int ShotCounter;
    public bool Attack = false;
    private float GunDelay;

    private NavMeshAgent agent;
    private NavMeshPath path;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        ShotInterval = Random.Range(ShotIntervalMinimum, ShotIntervalMaximum);
    }

    // Update is called once per frame
    void Update()
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

            
            if (!Attack)
            {
                // This checks to see if there is a player close enought to attack ... and if so... kill it!
                if (players.Count != 0)
                {
                    float closestDistanceSquare = Mathf.Infinity;
                    Vector3 currentPosition = transform.position;

                    foreach (GameObject potentialTarget in players)
                    {
                        Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
                        float dSquareToTarget = directionToTarget.sqrMagnitude;
                        if (dSquareToTarget < closestDistanceSquare)
                        {
                            closestDistanceSquare = dSquareToTarget;
                            ClosestPlayer = potentialTarget;
                        }
                    }

                    EnemyToPlayerDistance = Vector3.Distance(transform.position, ClosestPlayer.transform.position);

                    if (EnemyToPlayerDistance <= 15f)
                    {
                        Moving = false;
                        Attack = true;
                        agent.speed = 0f;
                    }
                }
            }
            else
            {
                EnemyToPlayerDistance = Vector3.Distance(transform.position, ClosestPlayer.transform.position);
                if (EnemyToPlayerDistance > 25f)
                {
                    Attack = false;
                    agent.speed = 2.5f;
                    Moving = true;
                    AtLocation = true;
                }
            }

            EnemyPlayerTime = 0;
        }
        
        if (Moving)
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

            Vector3 targetPosition = new Vector3(ClosestPlayer.transform.position.x, transform.position.y, ClosestPlayer.transform.position.z);
            transform.LookAt(targetPosition);

            if (ShotCounter < ShotInterval)
            {
                ShotCounter++;
            }
            else
            {
                CmdShootGunRight(BulletPrefab);
                ShotInterval = Random.Range(ShotIntervalMinimum, ShotIntervalMaximum);
                ShotCounter = 0;
            }
        }
    }

    [Command]
    void CmdShootGunRight(GameObject bullet)
    {
        GameObject BulletObj = Instantiate(bullet) as GameObject;

        int TargetRandomNumber = Random.Range(1, 99);

        if (TargetRandomNumber < 34)
        {
            RightGun.transform.LookAt(ClosestPlayer.transform.Find("TargetOne"));
        }
        else if (TargetRandomNumber >= 34 && TargetRandomNumber < 67)
        {
            RightGun.transform.LookAt(ClosestPlayer.transform.Find("TargetTwo"));
        }
        else if (TargetRandomNumber >= 67)
        {
            RightGun.transform.LookAt(ClosestPlayer.transform.Find("TargetThree"));
        }

        //  BulletObj.SetActive(true);
        NetworkServer.Spawn(BulletObj);
        BulletObj.transform.position = LaunchPositionRight.position;
        BulletObj.transform.rotation = LaunchPositionRight.rotation;

        BulletObj.GetComponent<Rigidbody>().AddForce(LaunchPositionRight.up * BulletSpeed * 1f, ForceMode.Impulse);
        GunDelay = Random.Range(0.0f, 0.3f);
        StartCoroutine("SecondGunDelay");
    }

    [Command]
    void CmdShootGunLeft(GameObject bullet)
    {
        GameObject BulletObj = Instantiate(bullet) as GameObject;

        int TargetRandomNumber = Random.Range(1, 99);

        if (TargetRandomNumber < 34)
        {
            LeftGun.transform.LookAt(ClosestPlayer.transform.Find("TargetOne"));
        }
        else if (TargetRandomNumber >= 34 && TargetRandomNumber < 67)
        {
            LeftGun.transform.LookAt(ClosestPlayer.transform.Find("TargetTwo"));
        }
        else if (TargetRandomNumber >= 67)
        {
            LeftGun.transform.LookAt(ClosestPlayer.transform.Find("TargetThree"));
        }

        //   BulletObj.SetActive(true);
        NetworkServer.Spawn(BulletObj);
        BulletObj.transform.position = LaunchPositionLeft.position;
        BulletObj.transform.rotation = LaunchPositionLeft.rotation;

        BulletObj.GetComponent<Rigidbody>().AddForce(LaunchPositionLeft.up * BulletSpeed * 1f, ForceMode.Impulse);
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

    IEnumerator LocationIdle()
    {
        yield return new WaitForSeconds(2f);
        CalculateMovingDestination();
    }

    IEnumerator SecondGunDelay()
    {
        yield return new WaitForSeconds(GunDelay);
        CmdShootGunLeft(BulletPrefab);
    }
}
