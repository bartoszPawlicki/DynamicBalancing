using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium : DifficultyLevel
{
    public Medium()
    {
        startingLife = 5;
        maxPlayerSpeed = 11;
        playerAcceleration = 1.7f;
        attackCooldown = 0.4f;
        bulletSpeed = 1000;
        bulletWeight = 1;

        meatClothHealth = 3;
        meatClothSpeedFactor = 800;
        meatClothMoveCooldown = 1.5f;
        meathClothShootCooldown = 2f;
        moveProbability = new List<float>() { 0.5f, 0.5f };

        fatEnemyHealth = 3;
        fatEnemySpeedFactor = 0.15f;
        fatEnemyAttackInterval = 0.9f;
        chaseTime = 2f;
        restTime = 2f;
        dashProbability = new List<float>() { 0.5f, 0.5f };
    }
    
}
