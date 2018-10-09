using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatMan : EnemyController
{
    public float speedFactor;
    public Cooldown movementCooldown;
    public Cooldown shootCooldown;
    public ObjectPool bulletPool;

    public List<float> moveProbability;
    

    void Start ()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        balancingSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<BalancingSystem>();

        //startHealth = balancingSystem.difficultyLevel.meatManhHealth;
        //currentHealth = startHealth;

        //speedFactor = balancingSystem.difficultyLevel.meatManhSpeedFactor;

        //shootCooldown.cooldownTime = balancingSystem.difficultyLevel.meathClothShootCooldown;
        //movementCooldown.cooldownTime = balancingSystem.difficultyLevel.meatManhMoveCooldown;

        //movementCooldown.InitCooldown();
        //shootCooldown.InitCooldown();
        
    }

    private void OnEnable()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        balancingSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<BalancingSystem>();
    }

    public override void DifficultyUpdate()
    {
        startHealth = balancingSystem.difficultyLevel.meatManhHealth;
        currentHealth = startHealth;

        speedFactor = balancingSystem.difficultyLevel.meatManhSpeedFactor;

        shootCooldown.cooldownTime = balancingSystem.difficultyLevel.meatManhShootCooldown;
        movementCooldown.cooldownTime = balancingSystem.difficultyLevel.meatManhMoveCooldown;
        

        movementCooldown.InitCooldown();
        shootCooldown.InitCooldown();
        

        if (balancingSystem.grade >= 1 && balancingSystem.grade < 3)
        {
            float moveChance = ((balancingSystem.grade - 1) * 0.1f);
            moveProbability = new List<float>() { moveChance, 1f - moveChance };
        }
        if (balancingSystem.grade >= 3 && balancingSystem.grade <= 11)
        {
            float moveChance = (0.2f + (balancingSystem.grade - 3) * 0.075f);
            moveProbability = new List<float>() { moveChance, 1f - moveChance };
        }
        if (balancingSystem.grade > 11 && balancingSystem.grade <= 13)
        {
            float moveChance = (0.8f + (balancingSystem.grade - 11) * 0.1f);
            moveProbability = new List<float>() { moveChance, 1f - moveChance };
        }
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
                
                int rand = BalancingSystem.RandomWithWeight(moveProbability);
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
