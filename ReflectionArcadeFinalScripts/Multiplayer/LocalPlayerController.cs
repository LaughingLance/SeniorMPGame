using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using InputTracking = UnityEngine.XR.InputTracking;
using Node = UnityEngine.XR.XRNode;

public class LocalPlayerController : NetworkBehaviour
{

    public GameObject ovrCamRig;
    public GameObject avatar;
    public Transform leftHand;
    public Transform rightHand;
    public Camera leftEye;
    public Camera rightEye;


	// Use this for initialization
	void Start ()
    {
		// will still need to set up player positioning on load
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!isLocalPlayer)
        {
            Destroy(ovrCamRig);
            Destroy(avatar);
            GetComponent<Player>().enabled = false;
        }
        else
        {
            // takes care of camera when another player joins
            if (leftEye.tag != "MainCamera")
            {
                leftEye.tag = "MainCamera";
                leftEye.enabled = true;
            }
            if (rightEye.tag != "MainCamera")
            {
                rightEye.tag = "MainCamera";
                rightEye.enabled = true;
            }

            // takes care of hand position tracking
            leftHand.localRotation = InputTracking.GetLocalRotation(Node.LeftHand);
            leftHand.localPosition = InputTracking.GetLocalPosition(Node.LeftHand);
            rightHand.localRotation = InputTracking.GetLocalRotation(Node.RightHand);
            rightHand.localPosition = InputTracking.GetLocalPosition(Node.RightHand);
        }
	}
}
