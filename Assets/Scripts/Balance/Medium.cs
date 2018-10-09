using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium : DifficultyLevel
{
    public Medium()
    {
        startingLife = 6;
        maxPlayerSpeed = 12;
        playerAcceleration = 10f;
        attackCooldown = 0.35f;
        bulletSpeed = 1000;
        bulletWeight = 1;

        meatManhHealth = 3;
        meatManhSpeedFactor = 800;
        meatManhMoveCooldown = 1.5f;
        meatManhShootCooldown = 2f;
        enemyBulletSpeed = 900;

        fatEnemyHealth = 3;
        fatEnemySpeedFactor = 0.15f;
        fatEnemyAttackInterval = 1.5f;
        chaseTime = 2f;
        restTime = 2f;

        baseEnemyCount = new List<int> { 2, 2, 3, 3, 4, 4, 4, 5 };
    }
    
}
