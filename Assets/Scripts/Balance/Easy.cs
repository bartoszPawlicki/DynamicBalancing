using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : DifficultyLevel
{
    public Easy()
    {
        startingLife = 8;
        maxPlayerSpeed = 12;
        playerAcceleration = 10f;
        attackCooldown = 0.3f;
        bulletSpeed = 1100;
        bulletWeight = 1;

        meatManhHealth = 2;
        meatManhSpeedFactor = 650;
        meatManhMoveCooldown = 2.5f;
        meatManhShootCooldown = 3f;
        enemyBulletSpeed = 750;

        fatEnemyHealth = 2;
        fatEnemySpeedFactor = 0.15f;
        fatEnemyAttackInterval = 2f;
        chaseTime = 1.5f;
        restTime = 1.5f;

        baseEnemyCount = new List<int> { 2, 2, 2, 3, 3, 3, 4, 4 };
    }
}
