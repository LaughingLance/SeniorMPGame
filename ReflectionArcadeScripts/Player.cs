using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject controller;
    GameController gameController;
    public int PlayerNumber;
    public Material PlayerOneBall;
    public Material PlayerTwoBall;
    public Material PlayerBallMaterial;
    //  GameObject dataController;
    //  PlayerDataController playerDataController;


    // Use this for initialization
    void Start()
    {
        controller = GameObject.Find("Game Controller");
        gameController = controller.GetComponent<GameController>();
        //     dataController = GameObject.Find("PlayerDataController");
        //     playerDataController = dataController.GetComponent<PlayerDataController>();        

        if (gameController.Players.Count == 0)
        {
            transform.gameObject.tag = "PlayerOne";
            transform.position = new Vector3(0, 0, -28);
            PlayerBallMaterial = PlayerOneBall;
            PlayerNumber = 1;
            gameController.Players.Add(gameObject);
            // This needs to be removed...
            gameController.PlayerTwoReady = true;
        }
        else 
        {
            transform.gameObject.tag = "PlayerTwo";
            transform.position = new Vector3(0, 0, 28);
            transform.rotation = new Quaternion(0, 1, 0, 0);
            PlayerBallMaterial = PlayerTwoBall;
            PlayerNumber = 2;
            gameController.Players.Add(gameObject);
        }
    }

    // Update is called once per frame
    void Update ()
    {
    
	}
}
