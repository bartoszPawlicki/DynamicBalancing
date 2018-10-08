using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : DifficultyLevel
{
    public Easy()
    {
        startingLife = 8;
        maxPlayerSpeed = 11;
        playerAcceleration = 2f;
        attackCooldown = 0.3f;
        bulletSpeed = 1100;
        bulletWeight = 1;

        meatClothHealth = 2;
        meatClothSpeedFactor = 650;
        meatClothMoveCooldown = 2.5f;
        meathClothShootCooldown = 3f;
        moveProbability = new List<float>() { 0.2f, 0.8f };

        fatEnemyHealth = 2;
        fatEnemySpeedFactor = 0.12f;
        fatEnemyAttackInterval = 2f;
        chaseTime = 1.5f;
        restTime = 1.5f;
        dashProbability = new List<float>() { 0.2f, 0.8f };
    }
}
