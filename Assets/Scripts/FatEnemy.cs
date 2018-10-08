using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatEnemy : EnemyController
{
    public float speedFactor;
    public Cooldown attackCooldown;
    public bool isChasing = true;
    
    public float chasingTimer;

    public float chaseTime;
    public float restTime;

    public List<float> dashProbability;
    
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

        chaseTime = balancingSystem.difficultyLevel.chaseTime;
        restTime = balancingSystem.difficultyLevel.restTime;

        chasingTimer = chaseTime;


        if(balancingSystem.grade >= 1 && balancingSystem.grade < 3)
        {
            float dashChance = ((balancingSystem.grade - 1) * 0.1f);
            dashProbability = new List<float>() { dashChance , 1f - dashChance };
        }
        if (balancingSystem.grade >= 3 && balancingSystem.grade <= 11)
        {
            float dashChance = (0.2f + (balancingSystem.grade - 3) * 0.075f);
            dashProbability = new List<float>() { dashChance, 1f - dashChance };
        }
        if (balancingSystem.grade > 11 && balancingSystem.grade <= 13)
        {
            float dashChance = (0.8f + (balancingSystem.grade - 11) * 0.1f);
            dashProbability = new List<float>() { dashChance, 1f - dashChance };
        }


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

                int rand = BalancingSystem.RandomWithWeight(dashProbability);
                if(rand == 0)
                {
                    ForwardDash();
                }
                else if (rand == 1)
                {
                    ConfusionDash();
                }
                
            }
            
        }
        else
        {
            Rest();
            chasingTimer -= Time.fixedDeltaTime;
            if (chasingTimer < 0)
            {
                isChasing = true;
                chasingTimer = chaseTime;
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

    void ForwardDash()
    {
        GetComponent<Rigidbody>().AddForce(transform.position + (playerController.gameObject.transform.position - transform.position).normalized * 900);
    }
}
