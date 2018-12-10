using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MPLIPandPort : MonoBehaviour
{
    public string IPAddressString;
    public string PortString;
    public Text IPAddress;
    public Text Port;

    public string IPNum1;
    public string IPNum2;
    public string IPNum3;
    public string IPNum4;
    public string IPNum5;
    public string IPNum6;
    public string IPNum7;
    public string IPNum8;
    public string IPNum9;
    public string IPNum10;
    public string IPNum11;
    public string IPNum12;
    public string IPNum13;
    public string IPNum14;
    public string IPNum15;
    public string IPNum16;

    public string PortNum1;
    public string PortNum2;
    public string PortNum3;
    public string PortNum4;
    public string PortNum5;

    public int IPNumberCount = 0;
    public int PortNumberCount = 0;

    public bool isKeyPressed = true;
    public bool isKeyboardActive = false;
    public bool isIPSelected = true;
    
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void UpdateAddress(string keyPress)
    {
        if (isIPSelected)
        {
            if (keyPress == "Close")
            {
                GameObject.Find("ClientEntryButton").GetComponent<MPLClientEntryButton>().isKeyboardMoving = true;
            }
            else if (keyPress == "Join")
            {
                NetworkManager.singleton.GetComponent<CustomNetworkMenu>().ipAddressClient = IPAddressString;
                NetworkManager.singleton.GetComponent<CustomNetworkMenu>().portClient = PortString;
                NetworkManager.singleton.GetComponent<CustomNetworkMenu>().JoinClient();
            }
            else if (keyPress == "Port")
            {
                isIPSelected = false;
            }
            else if (keyPress == "IP")
            {

            }
            else if (keyPress == "Delete")
            {
                if (IPNumberCount != 0)
                {
                    switch (IPNumberCount)
                    {
                        case 1:
                            IPNum1 = "";
                            IPAddressString = "";
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 2:
                            IPNum2 = "";
                            IPAddressString = IPNum1;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 3:
                            IPNum3 = "";
                            IPAddressString = IPNum1 + IPNum2;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 4:
                            IPNum4 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 5:
                            IPNum5 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 6:
                            IPNum6 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 7:
                            IPNum7 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 8:
                            IPNum8 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 9:
                            IPNum9 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 10:
                            IPNum10 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 11:
                            IPNum11 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 12:
                            IPNum12 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10 + IPNum11;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 13:
                            IPNum13 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10 + IPNum11 + IPNum12;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 14:
                            IPNum14 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10 + IPNum11 + IPNum12 + IPNum13;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 15:
                            IPNum15 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10 + IPNum11 + IPNum12 + IPNum13 + IPNum14;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                        case 16:
                            IPNum16 = "";
                            IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10 + IPNum11 + IPNum12 + IPNum13 + IPNum14 + IPNum15;
                            IPAddress.text = IPAddressString;
                            IPNumberCount--;
                            break;
                    }
                }
            }
            else
            {
                switch (IPNumberCount)
                {
                    case 0:
                        IPNum1 = keyPress;
                        IPAddressString = IPNum1;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 1:
                        IPNum2 = keyPress;
                        IPAddressString = IPNum1 + IPNum2;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 2:
                        IPNum3 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 3:
                        IPNum4 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 4:
                        IPNum5 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 5:
                        IPNum6 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 6:
                        IPNum7 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 7:
                        IPNum8 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 8:
                        IPNum9 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 9:
                        IPNum10 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 10:
                        IPNum11 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10 + IPNum11;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 11:
                        IPNum12 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10 + IPNum11 + IPNum12;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 12:
                        IPNum13 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10 + IPNum11 + IPNum12 + IPNum13;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 13:
                        IPNum14 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10 + IPNum11 + IPNum12 + IPNum13 + IPNum14;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 14:
                        IPNum15 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10 + IPNum11 + IPNum12 + IPNum13 + IPNum14 + IPNum15;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                    case 15:
                        IPNum16 = keyPress;
                        IPAddressString = IPNum1 + IPNum2 + IPNum3 + IPNum4 + IPNum5 + IPNum6 + IPNum7 + IPNum8 + IPNum9 + IPNum10 + IPNum11 + IPNum12 + IPNum13 + IPNum14 + IPNum15 + IPNum16;
                        IPAddress.text = IPAddressString;
                        IPNumberCount++;
                        break;
                }
            }
        }
        else
        {
            if (keyPress == "Close")
            {
                GameObject.Find("ClientEntryButton").GetComponent<MPLClientEntryButton>().isKeyboardMoving = true;
            }
            else if (keyPress == "Join")
            {
                NetworkManager.singleton.GetComponent<CustomNetworkMenu>().ipAddressClient = IPAddressString;
                NetworkManager.singleton.GetComponent<CustomNetworkMenu>().portClient = PortString;
                NetworkManager.singleton.GetComponent<CustomNetworkMenu>().JoinClient();
            }
            else if (keyPress == "IP")
            {
                isIPSelected = true;
            }
            else if (keyPress == "Port")
            {

            }
            else if (keyPress == "Delete")
            {
                if (PortNumberCount != 0)
                {
                    switch (PortNumberCount)
                    {
                        case 1:
                            PortNum1 = "";
                            PortString = "";
                            Port.text = PortString;
                            PortNumberCount--;
                            break;
                        case 2:
                            PortNum2 = "";
                            PortString = PortNum1;
                            Port.text = PortString;
                            PortNumberCount--;
                            break;
                        case 3:
                            PortNum3 = "";
                            PortString = PortNum1 + PortNum2;
                            Port.text = PortString;
                            PortNumberCount--;
                            break;
                        case 4:
                            PortNum4 = "";
                            PortString = PortNum1 + PortNum2 + PortNum3;
                            Port.text = PortString;
                            PortNumberCount--;
                            break;
                        case 5:
                            PortNum5 = "";
                            PortString = PortNum1 + PortNum2 + PortNum3 + PortNum4;
                            Port.text = PortString;
                            PortNumberCount--;
                            break;
                    }
                }
            }
            else
            {
                switch (PortNumberCount)
                {
                    case 0:
                        PortNum1 = keyPress;
                        PortString = PortNum1;
                        Port.text = PortString;
                        PortNumberCount++;
                        break;
                    case 1:
                        PortNum2 = keyPress;
                        PortString = PortNum1 + PortNum2;
                        Port.text = PortString;
                        PortNumberCount++;
                        break;
                    case 2:
                        PortNum3 = keyPress;
                        PortString = PortNum1 + PortNum2 + PortNum3;
                        Port.text = PortString;
                        PortNumberCount++;
                        break;
                    case 3:
                        PortNum4 = keyPress;
                        PortString = PortNum1 + PortNum2 + PortNum3 + PortNum4;
                        Port.text = PortString;
                        PortNumberCount++;
                        break;
                    case 4:
                        PortNum5 = keyPress;
                        PortString = PortNum1 + PortNum2 + PortNum3 + PortNum4 + PortNum5;
                        Port.text = PortString;
                        PortNumberCount++;
                        break;
                }
            }
        }
    }
}
