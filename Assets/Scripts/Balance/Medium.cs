using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium : DifficultyLevel
{
    public Medium()
    {
        startingLife = 6;
        maxPlayerSpeed = 11;
        playerAcceleration = 10f;
        attackCooldown = 0.35f;
        bulletSpeed = 1000;
        bulletWeight = 1;

        meatManhHealth = 3;
        meatManhSpeedFactor = 800;
        meatManhMoveCooldown = 1.5f;
        meatManhShootCooldown = 2f;

        fatEnemyHealth = 3;
        fatEnemySpeedFactor = 0.15f;
        fatEnemyAttackInterval = 0.9f;
        chaseTime = 2f;
        restTime = 2f;
    }
    
}
