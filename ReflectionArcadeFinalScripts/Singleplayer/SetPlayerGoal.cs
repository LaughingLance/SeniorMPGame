using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerGoal : MonoBehaviour
{
    public Material WhiteStripesOnYellow;
    public Material Rainbow;
    public Material Circus;
    public Material Mountain;
    public Material PirateFlag;

    Renderer rend;

    private GameObject dataController;
    PlayerDataController playerData;

    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();

        dataController = GameObject.Find("DataController");
        playerData = dataController.GetComponent<PlayerDataController>();

        switch (playerData.PlayerGoal)
        {
            case "WhiteStripesOnYellow":
                rend.material = WhiteStripesOnYellow;
                break;
            case "Rainbow":
                rend.material = Rainbow;
                break;
            case "Circus":
                rend.material = Circus;
                break;
            case "Mountains":
                rend.material = Mountain;
                break;
            case "PirateFlag":
                rend.material = PirateFlag;
                break;
        }
    }

}
