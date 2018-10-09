using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DifficultyLevel 
{
    public int startingLife = 5;
    public float maxPlayerSpeed = 11;
    public float playerAcceleration = 1.7f;
    public float attackCooldown = 0.4f;
    public float bulletSpeed = 1000;
    public float bulletWeight = 1;
    

    public int meatManhHealth = 3;
    public float meatManhSpeedFactor = 800;
    public float meatManhMoveCooldown = 1.5f;
    public float meatManhShootCooldown = 2f;
    public float enemyBulletSpeed = 900;

    public int fatEnemyHealth = 3;
    public float fatEnemySpeedFactor = 0.15f;
    public float fatEnemyAttackInterval = 0.9f;
    public float chaseTime = 2f;
    public float restTime = 2f;

    public List<int> baseEnemyCount = new List<int> { 2, 2, 2, 3, 3, 3, 4, 4 };
    


}
