﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerAndAccuse : MonoBehaviour
{
    public float timeLimit = 540;
    public Text clock;

    public CheckCircuit check;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;

        float minutes = timeLimit / 60;
        float seconds = timeLimit % 60;

        clock.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        if(timeLimit <= 0)
        {
            print("you lose");
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void Accuse()
    {
        if(check.closedCircuit == true)
        {
            print("you win!");
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            print("you lose");
            SceneManager.LoadScene("LoseScene");
        }
    }
}
