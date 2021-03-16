using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject finalTime;
    public GameObject timerText;
    public GameObject winCanvas;

    private Stopwatch sw;
    private Text text;
    private Text finalText;

    private bool GameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        sw = new Stopwatch();

        text = timerText.GetComponent<Text>();
        finalText = finalTime.GetComponent<Text>();

        sw.Start();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan ts = sw.Elapsed;
        text.text = string.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
    }

    public void ToggleState()
    {
        if (sw == null)
        {
            return;
        }

        if (GameIsPaused)
        {
            GameIsPaused = false;
            sw.Start();
        }
        else
        {
            GameIsPaused = true;
            sw.Stop();
        }
    }

    public void Win()
    {
        winCanvas.SetActive(true);
        finalText.text = text.text;
    }
}
