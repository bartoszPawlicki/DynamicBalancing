using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public ObjectPool bulletPool;
    public ObjectPool rocketPool;
    public Cooldown cooldown;
    public Cooldown rocketCooldown;
    public BalancingSystem balancingSystem;

    float shootHorizontal = 0;
    float shootVertical = 0;
    float lastShootHorizontal = 0;
    float lastShootVertical = 0;

    // Use this for initialization
    void Start ()
    {
        balancingSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<BalancingSystem>();
        cooldown.InitCooldown();
        rocketCooldown.InitCooldown();
    }

    public void UpdateDifficulty()
    {
        cooldown.cooldownTime = balancingSystem.difficultyLevel.attackCooldown;

        cooldown.InitCooldown();
        rocketCooldown.InitCooldown();
    }
    
    void Update()
    {
        if(!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().locked)
        {
            if (cooldown.canUse)
            {
                shootHorizontal = Input.GetAxis("HorizontalShoot");
                shootVertical = Input.GetAxis("VerticalShoot");

                if (shootHorizontal != 0)
                {
                    lastShootHorizontal = shootHorizontal;
                    Shoot(new Vector3(shootHorizontal, 0, 0));
                }

                else if (shootVertical != 0)
                {
                    lastShootVertical = shootVertical;
                    Shoot(new Vector3(0, 0, shootVertical));
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (rocketCooldown.canUse)
                {
                    shootHorizontal = lastShootHorizontal;
                    shootVertical = lastShootVertical;

                    if (shootHorizontal != 0)
                    {
                        ShootRocket(new Vector3(shootHorizontal, 0, 0));
                    }

                    else if (shootVertical != 0)
                    {
                        ShootRocket(new Vector3(0, 0, shootVertical));
                    }
                }
            }
            


        }
    }

    void Shoot(Vector3 direction)
    {
        cooldown.startTimer();

        Vector3 translationVec = Vector3.zero;

        if (direction.x < 0)
        {
            translationVec = Vector3.left;
        }
        else if (direction.x > 0)
        {
            translationVec = Vector3.right;
        }
        else if (direction.z < 0)
        {
            translationVec = Vector3.back;
        }
        else if (direction.z > 0)
        {
            translationVec = Vector3.forward;
        }
        GameObject bullet = bulletPool.PoolNext(transform.position + translationVec);

        bullet.GetComponent<Bullet>().StartBulletMovement(direction);
    }

    void ShootRocket(Vector3 direction)
    {
        rocketCooldown.startTimer();

        Vector3 translationVec = Vector3.zero;

        if (direction.x < 0)
        {
            translationVec = Vector3.left;
        }
        else if (direction.x > 0)
        {
            translationVec = Vector3.right;
        }
        else if (direction.z < 0)
        {
            translationVec = Vector3.back;
        }
        else if (direction.z > 0)
        {
            translationVec = Vector3.forward;
        }
        GameObject rocket = rocketPool.PoolNext(transform.position + translationVec * 3 + Vector3.up * 8);
        rocket.GetComponent<Rocket>().StartRocketMovement(Vector3.down);

    }
}
