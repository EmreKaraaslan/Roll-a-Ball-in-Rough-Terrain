using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI timerText;
    public float timeRemaining = 75f;

    GameFinish gameFinish;

    private void Start()
    {
        gameFinish = FindObjectOfType<GameFinish>();
    }
    void Update()
    {
        ProcessTime();
        DisplayTimeText();
        Debug.Log(timeRemaining);
    }

    private void DisplayTimeText()
    {
        timerText.text = "Time Left: " + (int)timeRemaining;
    }

    private void ProcessTime()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if(timeRemaining == 0)
        {
            timeRemaining = 0;
        }
    }
}
