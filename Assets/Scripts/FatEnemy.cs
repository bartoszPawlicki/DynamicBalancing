using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatEnemy : EnemyController
{
    public float speedFactor;
    public Cooldown attackCooldown;

    

    void Start()
    {

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        balancingSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<BalancingSystem>();

        //startHealth = balancingSystem.difficultyLevel.meatClothHealth;
        //currentHealth = startHealth;

        //speedFactor = balancingSystem.difficultyLevel.fatEnemySpeedFactor;

        //attackCooldown.cooldownTime = balancingSystem.difficultyLevel.fatEnemyAttackInterval;

        //attackCooldown.InitCooldown();
        



    }

    public override void DifficultyUpdate()
    {
        startHealth = balancingSystem.difficultyLevel.meatClothHealth;
        currentHealth = startHealth;

        speedFactor = balancingSystem.difficultyLevel.fatEnemySpeedFactor;

        attackCooldown.cooldownTime = balancingSystem.difficultyLevel.fatEnemyAttackInterval;

        attackCooldown.InitCooldown();
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        if (transform.parent.GetComponentInParent<LevelController>().delayOnLevelStartFinished)
        {
            Vector3 movement = transform.position + (playerController.gameObject.transform.position - transform.position).normalized * speedFactor;
            GetComponent<Rigidbody>().MovePosition(movement);
        }
            
    }

    void OnCollisionEnter(Collision collision)
    {
        if(attackCooldown.canUse)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                attackCooldown.startTimer();
                collision.gameObject.GetComponent<PlayerController>().ReceiveDamage(1);
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (attackCooldown.canUse)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                attackCooldown.startTimer();
                collision.gameObject.GetComponent<PlayerController>().ReceiveDamage(1);
            }
        }
    }
}
