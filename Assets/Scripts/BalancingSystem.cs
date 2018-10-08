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



	void Start ()
    {
        easy = new Easy();
        medium = new Medium();
        hard = new Hard();

        difficultyLevel = medium;

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
                grade = 6;
                break;
            case Difficulty.hard:
                difficultyLevel = hard;
                grade = 9;
                break;
        }
    }

    void GradeUp()
    {
        switch (difficulty)
        {
            case Difficulty.easy:
                
                if (grade >= 1 && grade < 4)
                {
                    grade++;
                }

                break;
            case Difficulty.medium:
                if (grade >= 4 && grade < 7)
                {
                    grade++;
                }
                break;
            case Difficulty.hard:
                if (grade >= 7 && grade < 10)
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

                if (grade > 1 && grade <= 4)
                {
                    grade--;
                }

                break;
            case Difficulty.medium:
                if (grade > 4 && grade <= 7)
                {
                    grade--;
                }
                break;
            case Difficulty.hard:
                if (grade > 7 && grade <= 10)
                {
                    grade--;
                }
                break;
        }
    }
	
    void UpdateGameToMatchGrade()
    {

    }

	void Update ()
    {
		
	}
}
