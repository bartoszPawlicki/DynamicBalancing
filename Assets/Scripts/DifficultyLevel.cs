using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DifficultyLevel 
{
    public static int startingLife = 5;
    public static float maxPlayerSpeed = 11;
    public static float playerAcceleration = 1.7f;
    public static float attackCooldown = 0.4f;
    public static float bulletSpeed = 1000;
    public static float bulletWeight = 1;

    public static int meatClothHealth = 3;
    public static float meatClothSpeedFactor = 800;
    public static float meatClothMoveCooldown = 1.5f;
    public static float meathClothShootCooldown = 2f;

    public static int fatEnemyHealth = 3;
    public static float fatEnemySpeedFactor = 0.15f;
    public static float fatEnemyAttackInterval = 0.9f;

}
