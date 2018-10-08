using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancingSystem : MonoBehaviour
{
    public enum Difficulty
    {
        easy, medium, hard
    }
    public int grade;

    public Easy easy;
    public Medium medium;
    public Hard hard;

    public DifficultyLevel difficultyLevel;
    public Difficulty difficulty;

    private PlayerController playerController;



	void Start ()
    {
        easy = new Easy();
        medium = new Medium();
        hard = new Hard();

        difficultyLevel = medium;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    public void InitWithDifficulty(Difficulty difficulty)
    {
        this.difficulty = difficulty;

        switch (difficulty)
        {
            case Difficulty.easy:
                grade = 3;
                difficultyLevel = easy;
                break;
            case Difficulty.medium:
                difficultyLevel = medium;
                grade = 7;
                break;
            case Difficulty.hard:
                difficultyLevel = hard;
                grade = 11;
                break;
        }
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<UberCanvasScript>().gradeText.text = grade.ToString();
    }

    void GradeUp()
    {
        switch (difficulty)
        {
            case Difficulty.easy:
                
                if (grade >= 1 && grade < 5)
                {
                    grade++;
                }

                break;
            case Difficulty.medium:
                if (grade >= 5 && grade < 9)
                {
                    grade++;
                }
                break;
            case Difficulty.hard:
                if (grade >= 9 && grade < 13)
                {
                    grade++;
                }
                break;
        }


    }

    void GradeDown()
    {
        switch (difficulty)
        {
            case Difficulty.easy:

                if (grade > 1 && grade <= 5)
                {
                    grade--;
                }

                break;
            case Difficulty.medium:
                if (grade > 5 && grade <= 9)
                {
                    grade--;
                }
                break;
            case Difficulty.hard:
                if (grade > 9 && grade <= 13)
                {
                    grade--;
                }
                break;
        }
    }

    public float startTime;
    public float startAccuracy;
    public float startHealth;

    public float endTime;
    public float endAccuracy;
    public float endHealth;



    public void StartGrading()
    {
        startTime = Time.time - GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<UberCanvasScript>().startTime;
        this.startAccuracy = startAccuracy;

        startHealth = playerController.currentHealth;
    }

    public void EndGrading()
    {
        this.endAccuracy = endAccuracy;
        endHealth = playerController.currentHealth;

        endTime = Time.time;

        GradePlayer();
    }

    public void GradePlayer()
    {
        float gradeDelta = 0;

        switch (difficulty)
        {
            case Difficulty.easy:
                gradeDelta += ((endHealth - startHealth)*0.4f);
                
                break;

            case Difficulty.medium:
                gradeDelta += ((endHealth - startHealth) * 0.5f);
                break;

            case Difficulty.hard:
                gradeDelta += ((endHealth - startHealth) * 1f);

                break;
        }

        if (gradeDelta <= -1)
        {
            GradeDown();
        }
        if (gradeDelta == 0)
        {
            GradeUp();
        }

        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<UberCanvasScript>().gradeText.text = grade.ToString();
    }

	void Update ()
    {
		
	}
    
    public static int RandomWithWeight(List<float> weights)
    {
        float rand = Random.Range(0f, 1f);
        Debug.Log(rand);
        float totalWeights = 0;

        for (int i=0; i<weights.Count; i++)
        {
            totalWeights += weights[i];
            if (rand <= totalWeights)
            {
                return i;
            }
        }
        return -1;
    }
}
