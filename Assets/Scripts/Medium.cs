using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium : DifficultyLevel
{
    public static new int startingLife = 5;
    public static new float maxPlayerSpeed = 11;
    public static new float playerAcceleration = 1.7f;
    public static new float attackCooldown = 0.4f;
    public static new float bulletSpeed = 1000;
    public static new float bulletWeight = 1;

    public new static int meatClothHealth = 3;
    public new static float meatClothSpeedFactor = 800;
    public new static float meatClothMoveCooldown = 1.5f;
    public new static float meathClothShootCooldown = 2f;

    public new static int fatEnemyHealth = 3;
    public new static float fatEnemySpeedFactor = 0.15f;
    public new static float fatEnemyAttackInterval = 0.9f;
}
