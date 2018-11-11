using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoTimer : MonoBehaviour
{
    public Text PlayerTwoTime;
    public int CurrentServerTime;

    private int GameMinutes;
    private int GameSeconds;
    private string Colon = ":";
    private string Minutes;
    private string Seconds;

    public GameObject NetworkGameTime;
    NetworkBroadcastingGameTimer NetworkTimer;

    void Start()
    {
        NetworkTimer = NetworkGameTime.GetComponent<NetworkBroadcastingGameTimer>();
    }

    void OnEnable()
    {
        NetworkBroadcastingGameTimer.OnTimeChange += ChangePlayerTwoTimer;
    }

    void OnDisable()
    {
        NetworkBroadcastingGameTimer.OnTimeChange -= ChangePlayerTwoTimer;
    }

    void ChangePlayerTwoTimer()
    {
        CurrentServerTime = NetworkTimer.gameTimeInt;
        if (CurrentServerTime / 60 >= 1)
        {
            GameMinutes = (int)(CurrentServerTime / 60);
            GameSeconds = CurrentServerTime - (GameMinutes * 60);
        }
        else if (CurrentServerTime / 60 < 1 && CurrentServerTime > 30)
        {
            GameMinutes = 0;
            GameSeconds = CurrentServerTime;
        }
        else if (CurrentServerTime / 60 < 1 && CurrentServerTime > 10)
        {
            PlayerTwoTime.color = Color.yellow;
            GameMinutes = 0;
            GameSeconds = CurrentServerTime;
        }
        else if (CurrentServerTime / 60 < 1 && CurrentServerTime > 0)
        {
            PlayerTwoTime.color = Color.red;
            GameMinutes = 0;
            GameSeconds = CurrentServerTime;
        }
        else
        {
            GameMinutes = 0;
            GameSeconds = 0;
        }
        Minutes = GameMinutes.ToString();
        Seconds = GameSeconds.ToString("d2");
        PlayerTwoTime.text = Minutes + Colon + Seconds;
    }
}
