using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerTag : MonoBehaviour
{
    public GameObject playerObject;
    Player player;

    private void OnEnable()
    {
        player = playerObject.GetComponent<Player>();
        if (player.PlayerNumber == 0)
        {
            transform.gameObject.tag = "PlayerOne";
        }
        else if (player.PlayerNumber == 1)
        {
            transform.gameObject.tag = "PlayerTwo";
        }
    }
}
