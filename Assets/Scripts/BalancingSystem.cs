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
    public Difficulty difficulty;


	void Start ()
    {
		switch(difficulty)
        {
            case Difficulty.easy:
                grade = 3;
                break;
            case Difficulty.medium:
                grade = 6;
                break;
            case Difficulty.hard:
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
