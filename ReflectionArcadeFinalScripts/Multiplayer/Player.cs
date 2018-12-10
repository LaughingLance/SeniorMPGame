using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public GameObject fadeObjectHolder;
    SceneFading fadeInOut;

    GameObject controller;
    GameController gameController;
    public int PlayerNumber;
    public string PlayerName;
    public Material PlayerBallMaterial;

    public GameObject leftController;
    public GameObject rightController;
    public GameObject leftSword;
    public GameObject rightSword;
    public GameObject leftClub;
    public GameObject rightClub;
    public GameObject leftHand;
    public GameObject rightHand;

    // player one ball materials
    public Material Black;
    public Material Grape;
    public Material Gray;
    //player two ball materials
    public Material Brown;
    public Material Red;
    public Material Yellow;

    // player Goal Materials;
    public Material WhiteStripesOnYellow;
    public Material Rainbow;
    public Material Circus;
    public Material Mountain;
    public Material PirateFlag;

    GameObject dataController;
    PlayerDataController playerDataController;

    public GameObject PlayerOneGoal;
    public GameObject PlayerTwoGoal;
    private Material playerOneGoalMaterial;
    private Material playerTwoGoalMaterial;
    Renderer playerOneGoalRend;
    Renderer playerTwoGoalRend;

    NetworkScoreTracker scoreTracker;

    // Use this for initialization
    void Start()
    {
        fadeInOut = fadeObjectHolder.GetComponent<SceneFading>();
        fadeInOut.FadeToClear();

        controller = GameObject.Find("Game Controller");
        gameController = controller.GetComponent<GameController>();
        dataController = GameObject.Find("DataController");
        playerDataController = dataController.GetComponent<PlayerDataController>();

        scoreTracker = GameObject.Find("GameScoreController").GetComponent<NetworkScoreTracker>();

        if (gameController.Players.Count == 0)
        {
            transform.gameObject.tag = "PlayerOne";
            leftController.tag = "PlayerOne";
            rightController.tag = "PlayerOne";
            leftSword.tag = "PlayerOne";
            rightSword.tag = "PlayerOne";
            leftClub.tag = "PlayerOne";
            rightClub.tag = "PlayerOne";
            leftHand.tag = "PlayerOne";
            rightHand.tag = "PlayerOne";
            transform.position = new Vector3(0, 0, -28);

            switch (playerDataController.PlayerOneBallMaterial)
            {
                case "Black":
                    PlayerBallMaterial = Black;
                    break;
                case "Grape":
                    PlayerBallMaterial = Grape;
                    break;
                case "Gray":
                    PlayerBallMaterial = Gray;
                    break;
            }

            PlayerOneGoal = GameObject.Find("GoalPlayerOne");
            playerOneGoalRend = PlayerOneGoal.GetComponent<Renderer>();

            switch (playerDataController.PlayerGoal)
            {
                case "WhiteStripesOnYellow":
                    playerOneGoalMaterial = WhiteStripesOnYellow;
                    break;
                case "Rainbow":
                    playerOneGoalMaterial = Rainbow;
                    break;
                case "Circus":
                    playerOneGoalMaterial = Circus;
                    break;
                case "Mountains":
                    playerOneGoalMaterial = Mountain;
                    break;
                case "PirateFlag":
                    playerOneGoalMaterial = PirateFlag;
                    break;
            }

            PlayerNumber = 1;
            PlayerName = playerDataController.PlayerName;
            gameController.Players.Add(gameObject);
        }
        else 
        {
            transform.gameObject.tag = "PlayerTwo";
            leftController.tag = "PlayerTwo";
            rightController.tag = "PlayerTwo";
            leftSword.tag = "PlayerTwo";
            rightSword.tag = "PlayerTwo";
            leftClub.tag = "PlayerTwo";
            rightClub.tag = "PlayerTwo";
            leftHand.tag = "PlayerTwo";
            rightHand.tag = "PlayerTwo";
            transform.position = new Vector3(0, 0, 28);
            transform.rotation = new Quaternion(0, 1, 0, 0);

            switch (playerDataController.PlayerTwoBallMaterial)
            {
                case "Brown":
                    PlayerBallMaterial = Brown;
                    break;
                case "Red":
                    PlayerBallMaterial = Red;
                    break;
                case "Yellow":
                    PlayerBallMaterial = Yellow;
                    break;
            }

            PlayerTwoGoal = GameObject.Find("GoalPlayerTwo");
            playerTwoGoalRend = PlayerTwoGoal.GetComponent<Renderer>();

            switch (playerDataController.PlayerGoal)
            {
                case "WhiteStripesOnYellow":
                    playerTwoGoalMaterial = WhiteStripesOnYellow;
                    break;
                case "Rainbow":
                    playerTwoGoalMaterial = Rainbow;
                    break;
                case "Circus":
                    playerTwoGoalMaterial = Circus;
                    break;
                case "Mountains":
                    playerTwoGoalMaterial = Mountain;
                    break;
                case "PirateFlag":
                    playerTwoGoalMaterial = PirateFlag;
                    break;
            }

            PlayerNumber = 2;
            PlayerName = playerDataController.PlayerName;
            gameController.Players.Add(gameObject);
            CmdStartTheGame();
        }
    }

    // Update is called once per frame
    void Update ()
    {
    
	}

    [Command]
    public void CmdStartTheGame()
    {
        gameController.PlayerOneReady = true;
        gameController.PlayerTwoReady = true;
    }

    [ClientRpc]
    public void RpcInitialGoalSetupPlayerOne()
    {
        if (isLocalPlayer)
        {
            playerOneGoalRend.material = playerOneGoalMaterial;
        }
    }

    [ClientRpc]
    public void RpcInitialGoalSetupPlayerTwo()
    {
        if (isLocalPlayer)
        {
            playerTwoGoalRend.material = playerTwoGoalMaterial;
        }
    }

    public void SaveGameData()
    {
        if (PlayerNumber == 1 && scoreTracker.GameWinner == "PlayerOne")
        {
            playerDataController.PlayerMtnValleyWins++;
        }
        else if (PlayerNumber == 2 && scoreTracker.GameWinner == "PlayerTwo")
        {
            playerDataController.PlayerMtnValleyWins++;
        }
        
        if (PlayerNumber == 1)
        {
            playerDataController.PlayerMountainVillageTopScore = scoreTracker.PlayerOneScore;
        }
        else if (PlayerNumber == 2)
        {
            playerDataController.PlayerMountainVillageTopScore = scoreTracker.PlayerTwoScore;
        }

        playerDataController.Save();
    }
}
