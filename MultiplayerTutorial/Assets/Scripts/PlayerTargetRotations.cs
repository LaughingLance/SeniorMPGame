using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetRotations : MonoBehaviour
{
    public Transform Player;
    public Transform BlasterTarget;

    private bool MoveUp;
    private bool MoveIn;

    // Use this for initialization
    void Start()
    {
        MoveUp = true;
        MoveIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        BlasterTarget.LookAt(Player);

        float dist = Vector3.Distance(Player.position, BlasterTarget.position);

        if (dist > 1.5f)
        {
            MoveIn = true;
        }
        else if (dist < 0.5f)
        {
            MoveIn = false;
        }

        if (BlasterTarget.transform.position.y < 1)
        {
            MoveUp = true;
        }
        else if (BlasterTarget.transform.position.y > 2)
        {
            MoveUp = false;
        }

        if (MoveUp)
        {
            BlasterTarget.transform.Translate(Vector3.up * Time.deltaTime * 1f);
        }
        else
        {
            BlasterTarget.transform.Translate(Vector3.up * Time.deltaTime * -1f);
        }

        if (MoveIn)
        {
            BlasterTarget.transform.Translate(Vector3.forward * Time.deltaTime * 1f);
        }
        else
        {
            BlasterTarget.transform.Translate(Vector3.forward * Time.deltaTime * -1f);
        }

        BlasterTarget.transform.Translate(Vector3.right * Time.deltaTime * 3f);
    }
}
