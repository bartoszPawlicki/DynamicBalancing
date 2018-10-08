using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatEnemy : EnemyController
{
    public float speedFactor;
    public Cooldown attackCooldown;
    public bool isChasing = true;

    public float chasingTotalTime = 4f;
    public float chasingTimer;

    

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        balancingSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<BalancingSystem>();
        chasingTimer = chasingTotalTime;
        //startHealth = balancingSystem.difficultyLevel.meatClothHealth;
        //currentHealth = startHealth;

        //speedFactor = balancingSystem.difficultyLevel.fatEnemySpeedFactor;

        //attackCooldown.cooldownTime = balancingSystem.difficultyLevel.fatEnemyAttackInterval;

        //attackCooldown.InitCooldown();
    }

    private void OnEnable()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        balancingSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<BalancingSystem>();
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
        if (isChasing)
        {
            Chase();
            chasingTimer -= Time.fixedDeltaTime;

            if (chasingTimer < 0)
            {
                isChasing = false;
                chasingTimer = 2f;
                ConfusionDash();
            }
            
        }
        else
        {
            Rest();
            chasingTimer -= Time.fixedDeltaTime;
            if (chasingTimer < 0)
            {
                isChasing = true;
                chasingTimer = chasingTotalTime;
            }
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

    void Chase()
    {
        if (transform.parent.GetComponentInParent<LevelController>().delayOnLevelStartFinished)
        {
            Vector3 movement = transform.position + (playerController.gameObject.transform.position - transform.position).normalized * speedFactor;
            GetComponent<Rigidbody>().MovePosition(movement);
        }
    }

    void Rest()
    {

    }

    void ConfusionDash()
    {
        GetComponent<Rigidbody>().AddForce(transform.position + (playerController.gameObject.transform.position - transform.position).normalized * -1100);
    }
}
