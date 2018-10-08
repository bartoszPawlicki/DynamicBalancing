using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard : DifficultyLevel
{
    public static new int startingLife = 3;
    public static new float maxPlayerSpeed = 11;
    public static new float playerAcceleration = 1.5f;
    public static new float attackCooldown = 0.5f;
    public static new float bulletSpeed = 900;
    public static new float bulletWeight = 1;

    public new static int meatClothHealth = 5;
    public new static float meatClothSpeedFactor = 900;
    public new static float meatClothMoveCooldown = 1.3f;
    public new static float meathClothShootCooldown = 1.7f;

    public new static int fatEnemyHealth = 4;
    public new static float fatEnemySpeedFactor = 0.16f;
    public new static float fatEnemyAttackInterval = 0.5f;
}
