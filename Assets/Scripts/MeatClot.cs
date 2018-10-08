﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatClot : EnemyController
{
    public float speedFactor;
    public Cooldown movementCooldown;
    public Cooldown shootCooldown;
    public ObjectPool bulletPool;

    void Start ()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        balancingSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<BalancingSystem>();

        //startHealth = balancingSystem.difficultyLevel.meatClothHealth;
        //currentHealth = startHealth;

        //speedFactor = balancingSystem.difficultyLevel.meatClothSpeedFactor;

        //shootCooldown.cooldownTime = balancingSystem.difficultyLevel.meathClothShootCooldown;
        //movementCooldown.cooldownTime = balancingSystem.difficultyLevel.meatClothMoveCooldown;

        //movementCooldown.InitCooldown();
        //shootCooldown.InitCooldown();
        
    }

    public override void DifficultyUpdate()
    {
        startHealth = balancingSystem.difficultyLevel.meatClothHealth;
        currentHealth = startHealth;

        speedFactor = balancingSystem.difficultyLevel.meatClothSpeedFactor;

        shootCooldown.cooldownTime = balancingSystem.difficultyLevel.meathClothShootCooldown;
        movementCooldown.cooldownTime = balancingSystem.difficultyLevel.meatClothMoveCooldown;

        movementCooldown.InitCooldown();
        shootCooldown.InitCooldown();
    }

    void Update ()
    {

	}

    void FixedUpdate()
    {
        if(transform.parent.GetComponentInParent<LevelController>().delayOnLevelStartFinished)
        {
            if (movementCooldown.canUse)
            {
                movementCooldown.startTimer();
                //Vector3 movement = transform.position + (transform.position + new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)) - transform.position).normalized * speedFactor;
                //GetComponent<Rigidbody>().MovePosition(movement);
                GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized * speedFactor);
            }
            if (shootCooldown.canUse)
            {
                
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    Shoot();
                }
                else
                {
                    ShootWeak();   
                }
            }
        }
        
    }

    void Shoot()
    {
        shootCooldown.startTimer();
        GameObject bullet0 = bulletPool.PoolNext(transform.position + Vector3.left);
        GameObject bullet1 = bulletPool.PoolNext(transform.position + Vector3.right);
        GameObject bullet2 = bulletPool.PoolNext(transform.position + Vector3.back);
        GameObject bullet3 = bulletPool.PoolNext(transform.position + Vector3.forward);

        bullet0.GetComponent<EnemyBullet>().StartBulletMovement(Vector3.left);
        bullet1.GetComponent<EnemyBullet>().StartBulletMovement(Vector3.right);
        bullet2.GetComponent<EnemyBullet>().StartBulletMovement(Vector3.back);
        bullet3.GetComponent<EnemyBullet>().StartBulletMovement(Vector3.forward);
    }

    void ShootWeak()
    {
        shootCooldown.startTimer();

        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            
            GameObject bullet0 = bulletPool.PoolNext(transform.position + Vector3.left);
            GameObject bullet1 = bulletPool.PoolNext(transform.position + Vector3.right);
            bullet0.GetComponent<EnemyBullet>().StartBulletMovement(Vector3.left);
            bullet1.GetComponent<EnemyBullet>().StartBulletMovement(Vector3.right);
        }
        else
        {
            GameObject bullet2 = bulletPool.PoolNext(transform.position + Vector3.back);
            GameObject bullet3 = bulletPool.PoolNext(transform.position + Vector3.forward);
            bullet2.GetComponent<EnemyBullet>().StartBulletMovement(Vector3.back);
            bullet3.GetComponent<EnemyBullet>().StartBulletMovement(Vector3.forward);
        }
    }
}
