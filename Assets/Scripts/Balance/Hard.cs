using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard : DifficultyLevel
{
    public Hard()
    {
        startingLife = 4;
        maxPlayerSpeed = 12;
        playerAcceleration = 10f;
        attackCooldown = 0.4f;
        bulletSpeed = 900;
        bulletWeight = 1;

        meatManhHealth = 5;
        meatManhSpeedFactor = 950;
        meatManhMoveCooldown = 1.2f;
        meatManhShootCooldown = 1.6f;
        enemyBulletSpeed = 1050;

        fatEnemyHealth = 4;
        fatEnemySpeedFactor = 0.15f;
        fatEnemyAttackInterval = 1f;
        chaseTime = 3f;
        restTime = 1f;

        baseEnemyCount = new List<int> { 3, 3, 4, 4, 4, 5, 5, 5 };
    }
}
