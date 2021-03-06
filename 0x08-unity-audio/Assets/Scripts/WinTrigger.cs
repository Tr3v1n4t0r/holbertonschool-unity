﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject TextObj;
    public GameObject PlayerObj;

    private Text text;
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        text = TextObj.GetComponent<Text>();
        timer = PlayerObj.GetComponent<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        timer.enabled = false;
        text.fontSize = 60;
        text.color = Color.green;
        Cursor.lockState = CursorLockMode.None;
        timer.Win();
        timer.enabled = false;
        text.text = "";
    }
}
