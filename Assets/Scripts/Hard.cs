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
        meatClothMoveCooldown = 1.2f;
        meatClothShootCooldown = 1.6f;

        fatEnemyHealth = 4;
        fatEnemySpeedFactor = 0.15f;
        fatEnemyAttackInterval = 0.5f;
        chaseTime = 3f;
        restTime = 1f;
    }
}
