using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatEnemy : EnemyController
{
    public float speedFactor;
	
	void Start ()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        currentHealth = startHealth;
    }
	
	
	void Update ()
    {
    }

    void FixedUpdate()
    {
        Vector3 movement = transform.position + (playerController.gameObject.transform.position - transform.position).normalized * speedFactor;
        GetComponent<Rigidbody>().MovePosition(movement);
    }
}
