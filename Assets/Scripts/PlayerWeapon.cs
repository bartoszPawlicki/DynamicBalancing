using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Cooldown cooldown;

    float shootHorizontal = 0;
    float shootVertical = 0;

    // Use this for initialization
    void Start ()
    {
        cooldown.InitCooldown();
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
                    Shoot(new Vector3(shootHorizontal, 0, 0));
                }

                else if (shootVertical != 0)
                {
                    Shoot(new Vector3(0, 0, shootVertical));
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
}
