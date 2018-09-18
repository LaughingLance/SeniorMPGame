using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NetControl : MonoBehaviour
{
    public static NetControl controller;

    private void Awake()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
    }
}
