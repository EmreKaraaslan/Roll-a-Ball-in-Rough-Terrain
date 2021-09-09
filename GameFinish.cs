using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameFinish : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] GameObject restartUI;
    [SerializeField] GameObject nextLevelUI;
    [SerializeField] bool isSuccessful;

    DisplayCount displayCount;
    TimeCounter timeCounter;
    Scene scene;

    int activeSceneIndex;
    int nextSceneIndex;
    bool isLastLevel;
    
    private void Start()
    {
        displayCount = FindObjectOfType<DisplayCount>();
        timeCounter = FindObjectOfType<TimeCounter>();
        restartUI.SetActive(false);
        nextLevelUI.SetActive(false);
        GetActiveSceneInfo();
    
    }

   

    private void Update()
    {
        DisplayWinText();
        GetSuccessInfo();
        DecideGameSituation();
    }

    void DecideGameSituation()
    {
        if (activeSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            isLastLevel = false;
        }
        else
        {
            isLastLevel = true;
        }
    }
    public void NextLevelGame()
    {
        winText.text = "  You Win!";
        Invoke("NextLevelProcess", 1f);
    }

    public void NextLevelProcess()
    {
        Time.timeScale = 0;
        restartUI.SetActive(true);
        nextLevelUI.SetActive(true);
    }

    public void StayLevelGame()
    {
        winText.text = " You Lost!";
        Invoke("StayLevelProcess", 1f);
    }

    public void StayLevelProcess()
    {
        Time.timeScale = 0;
        restartUI.SetActive(true);
    }

    public void GameOver()
    {
        winText.text = "Game Over!";
        Invoke("GameOverProcess", 1f);
    }

    public void GameOverProcess()
    {
        Time.timeScale = 0;
        restartUI.SetActive(true);
    }


    void DisplayWinText()
    {
        if (displayCount.GetCount() == displayCount.numberofPickup && !isLastLevel && isSuccessful)
        {
            NextLevelGame();
        }
        
        else if(displayCount.GetCount() == displayCount.numberofPickup && isLastLevel && isSuccessful)
        {
            GameOver();
        }

        else if (timeCounter.timeRemaining <0.5f && !isSuccessful)
        {
            StayLevelGame();
        }

        else
        {
            winText.text = "";
        }


    }


    void GetSuccessInfo()
    {
        if(timeCounter.timeRemaining>0 && displayCount.GetCount() == displayCount.numberofPickup)
        {
            isSuccessful = true;
        }

    }
    private void GetActiveSceneInfo()
    {
        scene = SceneManager.GetActiveScene();
        activeSceneIndex = scene.buildIndex;
        nextSceneIndex = scene.buildIndex+1;
    }

    public void Restart()
    {
        if(!isLastLevel || !isSuccessful)
        {
           SceneManager.LoadScene(activeSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }

    public void NextLevel()
    {
        if(!isLastLevel)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
       
    }

}
