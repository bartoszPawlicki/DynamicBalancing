using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UberCanvasScript : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI accucaryText;
    public TextMeshProUGUI gradeText;
    public bool gameOver = false;

    public float startTime;
    private float currentTime;

    public int bulletsShot = 0;
    public int bulletsHit = 0;

    public GameObject mainMenu;
    public GameObject gameOverMenu;
    public GameObject victoryMenu;
    public BalancingSystem balancingSystem;

    public bool timerStarted = false;

    void Start ()
    {
        balancingSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<BalancingSystem>();
    }
	
	void Update ()
    {
        if(timerStarted && !gameOver)
        {
            int minutes = (int)((Time.time - startTime) / 60);
            int seconds = (int)((Time.time - startTime) % 60);
            int fraction = (int)(((Time.time - startTime) * 1000) % 1000);


            timeText.text = String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
            //timeText.text = (Time.time - startTime).ToString(); 
            float whole = Mathf.FloorToInt((bulletsHit * 1f / bulletsShot * 100));
            float fract = ((bulletsHit * 1f / bulletsShot * 100)) - whole;
            accucaryText.text = String.Format("{0},{1:00}%", whole, fract);
        }
	}

    public void StartGameEasy()
    {
        balancingSystem.InitWithDifficulty(BalancingSystem.Difficulty.easy);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UpdateDifficulty();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeapon>().UpdateDifficulty();
        mainMenu.SetActive(false);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameZDirector>().startingLevel.StartLevel(DoorController.DoorLocation.RIGHT);
        StartGameTimer();
        
        
    }

    public void StartGameMedium()
    {
        balancingSystem.InitWithDifficulty(BalancingSystem.Difficulty.medium);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UpdateDifficulty();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeapon>().UpdateDifficulty();
        mainMenu.SetActive(false);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameZDirector>().startingLevel.StartLevel(DoorController.DoorLocation.RIGHT);
        StartGameTimer();
    }

    public void StartGameHard()
    {
        balancingSystem.InitWithDifficulty(BalancingSystem.Difficulty.hard);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UpdateDifficulty();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeapon>().UpdateDifficulty();
        mainMenu.SetActive(false);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameZDirector>().startingLevel.StartLevel(DoorController.DoorLocation.RIGHT);
        StartGameTimer();
    }

    public void StartGameTimer()
    {
        timerStarted = true;
        startTime = Time.time;
        accucaryText.text = "100%";
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        gameOver = true;
        gradeText.gameObject.SetActive(true);
    }

    public void Victory()
    {
        victoryMenu.SetActive(true);
        gameOver = true;
        gradeText.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
