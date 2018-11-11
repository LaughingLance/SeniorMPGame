using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsMenu : MonoBehaviour
{
    public string PlayerNameString;
    public Text PlayerName;

    public string letterOne;
    public string letterTwo;
    public string letterThree;
    public string letterFour;
    public string letterFive;
    public string letterSix;
    public string letterSeven;
    public string letterEight;
    public string letterNine;
    public string letterTen;

    public int PlayerNameLetterCount = 0;
    public bool isKeyPressed = true;
    public bool isKeyboardActive = false;

    public GameObject Keyboard;

    public Text TopCircusScoreTotal;
    public Text TopMVScoreTotal;
    public Text CircusGamesPlayedTotal;
    public Text MVGamesWonTotal;

    public Text Error;
    public GameObject ErrorBackground;

    private GameObject dataController;
    PlayerDataController playerData;

    // Use this for initialization
    void Start ()
    {
        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();

        PlayerName.text = playerData.PlayerName;

    }

    public void UpdatePlayerStatsMenu()
    {
        playerData.Load();
        PlayerName.text = playerData.PlayerName;
        TopCircusScoreTotal.text = playerData.PlayerCircusTopScore.ToString();
        TopMVScoreTotal.text = playerData.PlayerMountainVillageTopScore.ToString();
        CircusGamesPlayedTotal.text = playerData.PlayerCircusPlays.ToString();
        MVGamesWonTotal.text = playerData.PlayerMtnValleyWins.ToString();
    }

    public void UpdatePlayerName(string keyPress)
    {        
        if (keyPress == "Enter")
        {
            playerData.PlayerName = PlayerNameString;
            Keyboard.SetActive(false);
            isKeyboardActive = false;
            playerData.Save();
        }
        else if (keyPress == "Space")
        {
            switch (PlayerNameLetterCount)
            {
                case 0:
                    letterOne = " ";
                    PlayerNameString = letterOne;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 1:
                    letterTwo = " ";
                    PlayerNameString = letterOne + letterTwo;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 2:
                    letterThree = " ";
                    PlayerNameString = letterOne + letterTwo + letterThree;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 3:
                    letterFour = " ";
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 4:
                    letterFive = " ";
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 5:
                    letterSix = " ";
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 6:
                    letterSeven = " ";
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix + letterSeven;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 7:
                    letterEight = " ";
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix + letterSeven + letterEight;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 8:
                    letterNine = " ";
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix + letterSeven + letterEight + letterNine;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 9:
                    letterTen = " ";
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix + letterSeven + letterEight + letterNine + letterTen;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 10:
                    Error.gameObject.SetActive(true);
                    ErrorBackground.SetActive(true);
                    StartCoroutine("ErrorMessage");
                    break;
            }
        }
        else if (keyPress == "Delete")
        {
            if (PlayerNameLetterCount != 0)
            {
                switch (PlayerNameLetterCount)
                {
                    case 1:
                        letterOne = "";
                        PlayerNameString = "";
                        PlayerName.text = PlayerNameString;
                        PlayerNameLetterCount--;
                        break;
                    case 2:
                        letterTwo = "";
                        PlayerNameString = letterOne;
                        PlayerName.text = PlayerNameString;
                        PlayerNameLetterCount--;
                        break;
                    case 3:
                        letterThree = "";
                        PlayerNameString = letterOne + letterTwo;
                        PlayerName.text = PlayerNameString;
                        PlayerNameLetterCount--;
                        break;
                    case 4:
                        letterFour = "";
                        PlayerNameString = letterOne + letterTwo + letterThree;
                        PlayerName.text = PlayerNameString;
                        PlayerNameLetterCount--;
                        break;
                    case 5:
                        letterFive = "";
                        PlayerNameString = letterOne + letterTwo + letterThree + letterFour;
                        PlayerName.text = PlayerNameString;
                        PlayerNameLetterCount--;
                        break;
                    case 6:
                        letterSix = "";
                        PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive;
                        PlayerName.text = PlayerNameString;
                        PlayerNameLetterCount--;
                        break;
                    case 7:
                        letterSeven = "";
                        PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix;
                        PlayerName.text = PlayerNameString;
                        PlayerNameLetterCount--;
                        break;
                    case 8:
                        letterEight = "";
                        PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix + letterSeven;
                        PlayerName.text = PlayerNameString;
                        PlayerNameLetterCount--;
                        break;
                    case 9:
                        letterNine = "";
                        PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix + letterSeven + letterEight;
                        PlayerName.text = PlayerNameString;
                        PlayerNameLetterCount--;
                        break;
                    case 10:
                        letterTen = "";
                        PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix + letterSeven + letterEight + letterNine;
                        PlayerName.text = PlayerNameString;
                        PlayerNameLetterCount--;
                        break;
                }
            }
        }
        else
        {
            switch (PlayerNameLetterCount)
            {
                case 0:
                    letterOne = keyPress;
                    PlayerNameString = letterOne;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 1:
                    letterTwo = keyPress;
                    PlayerNameString = letterOne + letterTwo;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 2:
                    letterThree = keyPress;
                    PlayerNameString = letterOne + letterTwo + letterThree;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 3:
                    letterFour = keyPress;
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 4:
                    letterFive = keyPress;
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 5:
                    letterSix = keyPress;
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 6:
                    letterSeven = keyPress;
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix + letterSeven;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 7:
                    letterEight = keyPress;
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix + letterSeven + letterEight;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 8:
                    letterNine = keyPress;
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix + letterSeven + letterEight + letterNine;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 9:
                    letterTen = keyPress;
                    PlayerNameString = letterOne + letterTwo + letterThree + letterFour + letterFive + letterSix + letterSeven + letterEight + letterNine + letterTen;
                    PlayerName.text = PlayerNameString;
                    PlayerNameLetterCount++;
                    break;
                case 10:
                    Error.gameObject.SetActive(true);
                    ErrorBackground.SetActive(true);
                    StartCoroutine("ErrorMessage");
                    break;
            }            
        }
    }

    IEnumerator ErrorMessage()
    {
        yield return new WaitForSeconds(5f);
        Error.gameObject.SetActive(false);
        ErrorBackground.SetActive(false);
    }
}
