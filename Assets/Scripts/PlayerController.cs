using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speedFactor;

    [SerializeField]
    private float startHealth;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private float currentHealth;

    private float moveHorizontal = 0;
    private float moveVertical = 0;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        currentHealth = startHealth;

    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");


        if (moveHorizontal != 0 || moveVertical != 0)
        {
            Vector3 movement = transform.position + new Vector3(moveHorizontal, 0, moveVertical) * speedFactor;
            rigidbody.MovePosition(movement);
        }


    }

    public void ReceiveHealing(float healthValue)
    {
        if (currentHealth < maxHealth)
        {
            if (currentHealth + healthValue > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += healthValue;
            }
        }
    }
}
