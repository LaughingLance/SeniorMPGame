using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerOneTimer : NetworkBehaviour
{
    public Text PlayerOneTime;
    public int CurrentServerTime;
    public GameObject NetworkGameTime;
    public GameObject WarningSpeaker;
    public AudioClip WarningSound;

    private int GameMinutes;
    private int GameSeconds;
    private string Colon = ":";
    private string Minutes;
    private string Seconds;

    NetworkBroadcastingGameTimer NetworkTimer;
    AudioSource WarningSpeakerSource;

    void Start()
    {
        NetworkTimer = NetworkGameTime.GetComponent<NetworkBroadcastingGameTimer>();
        WarningSpeakerSource = WarningSpeaker.GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        NetworkBroadcastingGameTimer.OnTimeChange += ChangePlayerOneTimer;
    }

    void OnDisable()
    {
        NetworkBroadcastingGameTimer.OnTimeChange -= ChangePlayerOneTimer;
    }

    void ChangePlayerOneTimer()
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
            PlayerOneTime.color = Color.yellow;
            GameMinutes = 0;
            GameSeconds = CurrentServerTime;
        }
        else if (CurrentServerTime / 60 < 1 && CurrentServerTime > 0)
        {
            WarningSpeakerSource.PlayOneShot(WarningSound, 1f);
            PlayerOneTime.color = Color.red;
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
        RpcUpdateTimer();
    }

    [ClientRpc]
    public void RpcUpdateTimer()
    {
        PlayerOneTime.text = Minutes + Colon + Seconds;
    }
}
