using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard : DifficultyLevel
{
    public Hard()
    {
        startingLife = 3;
        maxPlayerSpeed = 11;
        playerAcceleration = 1.5f;
        attackCooldown = 0.5f;
        bulletSpeed = 900;
        bulletWeight = 1;

        meatClothHealth = 5;
        meatClothSpeedFactor = 900;
        meatClothMoveCooldown = 1.3f;
        meathClothShootCooldown = 1.7f;
        moveProbability = new List<float>() { 0.8f, 0.2f };

        fatEnemyHealth = 4;
        fatEnemySpeedFactor = 0.16f;
        fatEnemyAttackInterval = 0.5f;
        chaseTime = 3f;
        restTime = 1f;
        dashProbability = new List<float>() { 0.8f, 0.2f };
    }
}
