using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : DifficultyLevel
{
    public static new int startingLife = 8;
    public static new float maxPlayerSpeed = 11;
    public static new float playerAcceleration = 2f;
    public static new float attackCooldown = 0.3f;
    public static new float bulletSpeed = 1100;
    public static new float bulletWeight = 1;

    public new static int meatClothHealth = 2;
    public new static float meatClothSpeedFactor = 650;
    public new static float meatClothMoveCooldown = 2.5f;
    public new static float meathClothShootCooldown = 3f;

    public new static int fatEnemyHealth = 2;
    public new static float fatEnemySpeedFactor = 0.12f;
    public new static float fatEnemyAttackInterval = 2f;
}
