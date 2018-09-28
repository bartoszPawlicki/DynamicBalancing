using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UberCanvasScript : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI accucaryText;

    private float startTime;
    private float currentTime;

    public int bulletsShot = 0;
    public int bulletsHit = 0;

    void Start ()
    {
        StartGameTimer();
    }
	
	void Update ()
    {
        int minutes = (int) ((Time.time - startTime) / 60);
        int seconds = (int)((Time.time - startTime) % 60);
        int fraction = (int)(((Time.time - startTime) * 1000) % 1000);


        timeText.text = String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        //timeText.text = (Time.time - startTime).ToString(); 
        float whole = Mathf.FloorToInt((bulletsHit * 1f / bulletsShot * 100));
        float fract = ((bulletsHit * 1f / bulletsShot * 100)) - whole;
        accucaryText.text = String.Format("{0},{1:00}%", whole, fract); 
	}

    public void StartGameTimer()
    {
        startTime = Time.time;
        accucaryText.text = "100%";
    }
}
