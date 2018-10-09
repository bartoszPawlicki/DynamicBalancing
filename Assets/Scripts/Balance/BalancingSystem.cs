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
    public float gradeDelta = 0;

    public Easy easy;
    public Medium medium;
    public Hard hard;

    public DifficultyLevel difficultyLevel;
    public Difficulty difficulty;

    private PlayerController playerController;
    private UberCanvasScript canvas;



    void Start()
    {
        easy = new Easy();
        medium = new Medium();
        hard = new Hard();

        difficultyLevel = medium;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<UberCanvasScript>();

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
        canvas.gradeText.text = grade.ToString();
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
                gradeDelta -= 1;

                break;
            case Difficulty.medium:
                if (grade >= 5 && grade < 9)
                {
                    grade++;
                }
                gradeDelta += 1;
                break;
            case Difficulty.hard:
                if (grade >= 9 && grade < 13)
                {
                    grade++;
                }
                break;
                gradeDelta += 1;
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
                gradeDelta += 1;

                break;
            case Difficulty.medium:
                if (grade > 5 && grade <= 9)
                {
                    grade--;
                }
                gradeDelta += 1;
                break;
            case Difficulty.hard:
                if (grade > 9 && grade <= 13)
                {
                    grade--;
                }
                gradeDelta += 1;
                break;
        }
    }

    public float startTime;
    public float startAccuracy;
    public float startHealth;

    public float endTime;
    public float endAccuracy;
    public float endHealth;

    public float bulletsHitStart;
    public float bulletsHitEnd;
    public float bulletsFiredStart;
    public float bulletsFiredEnd;


    public void StartGrading()
    {
        startTime = Time.time - canvas.startTime;
        bulletsHitStart = canvas.bulletsHit;
        bulletsFiredStart = canvas.bulletsShot;

        startHealth = playerController.currentHealth;
    }

    public void EndGrading()
    {
        bulletsHitEnd = canvas.bulletsHit - bulletsHitStart;
        bulletsFiredEnd = canvas.bulletsShot - bulletsFiredStart;

        endHealth = playerController.currentHealth;

        endTime = Time.time;

        GradePlayer();
    }

    public void GradePlayer()
    {

        float healthDelta = (endHealth - startHealth);

        float timeBonus = 0;
        float healthBonus = 0;
        float accBonus = 0;

        Debug.Log(endTime - startTime);

        switch (difficulty)
        {
            case Difficulty.easy:
                healthBonus = (healthDelta * 0.4f);
                
                accBonus = (-0.1f + (bulletsHitEnd / bulletsFiredEnd) * 0.5f);

                if ((endTime - startTime) > 60)
                {
                    timeBonus = -0.6f;
                }
                else
                {
                    timeBonus = (0.5f - (endTime - startTime) / 60f);
                }


                if (healthDelta != 0)
                {
                    timeBonus /= (healthDelta * -1);
                    accBonus /= (healthDelta * -1);
                }
                gradeDelta += timeBonus + accBonus + healthBonus;
                Debug.Log("timeBonus: " + timeBonus + " accBonus: " + accBonus + " healthBonus: " + healthBonus + " gradeDelta: " + gradeDelta);

                

                break;

            case Difficulty.medium:
                healthBonus = (healthDelta * 0.5f);
                
                accBonus = (-0.1f + (bulletsHitEnd / bulletsFiredEnd) * 0.5f);

                if ((endTime - startTime) > 60)
                {
                    timeBonus = -0.6f;
                }
                else
                {
                    timeBonus = (0.5f - (endTime - startTime) / 60f);
                }


                if (healthDelta != 0)
                {
                    timeBonus /= (healthDelta * -1);
                    accBonus /= (healthDelta * -1);
                }
                gradeDelta += timeBonus + accBonus + healthBonus;
                Debug.Log("timeBonus: " + timeBonus + " accBonus: " + accBonus + " healthBonus: " + healthBonus + " gradeDelta: " + gradeDelta);

                

                break;

            case Difficulty.hard:
                healthBonus = (healthDelta * 0.6f);
                
                accBonus = (-0.1f + (bulletsHitEnd / bulletsFiredEnd) * 0.5f);

                if ((endTime - startTime) > 60)
                {
                    timeBonus = -0.6f;
                }
                else
                {
                    timeBonus = (0.5f - (endTime - startTime) / 60f);
                }


                if (healthDelta != 0)
                {
                    timeBonus /= (healthDelta * -1);
                    accBonus /= (healthDelta * -1);
                }
                gradeDelta += timeBonus + accBonus + healthBonus;
                Debug.Log("timeBonus: " + timeBonus + " accBonus: " + accBonus + " healthBonus: " + healthBonus + " gradeDelta: " + gradeDelta);

                

                break;
        }

        if (gradeDelta <= -1)
        {
            GradeDown();
        }
        if (gradeDelta >= 1f)
        {
            GradeUp();
        }

        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<UberCanvasScript>().gradeText.text = grade.ToString();
    }

    void Update()
    {

    }

    public static int RandomWithWeight(List<float> weights)
    {
        float rand = Random.Range(0f, 1f);
        //Debug.Log(rand);
        float totalWeights = 0;

        for (int i = 0; i < weights.Count; i++)
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
