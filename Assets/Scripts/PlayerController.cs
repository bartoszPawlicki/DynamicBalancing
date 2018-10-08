using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidbody;

    [SerializeField]
    private float playerAcceleration;

    
    private float startHealth;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    public float currentHealth;

    private float moveHorizontal = 0;
    private float moveVertical = 0;

    [SerializeField]
    public float maxSpeed;

    private ParticleSystem damageParticles;

    private UberCanvasScript canvas;
    public BalancingSystem balancingSystem;

    public bool locked = true;

    void Start()
    {
        balancingSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<BalancingSystem>();
        rigidbody = GetComponent<Rigidbody>();

        //startHealth = balancingSystem.difficultyLevel.startingLife;

        damageParticles = GetComponentInChildren<ParticleSystem>();
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<UberCanvasScript>();
    }

    public void UpdateDifficulty()
    {
        startHealth = balancingSystem.difficultyLevel.startingLife;
        currentHealth = startHealth;
        canvas.healthText.text = currentHealth.ToString();
        playerAcceleration = balancingSystem.difficultyLevel.playerAcceleration;
        maxSpeed = balancingSystem.difficultyLevel.maxPlayerSpeed;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!locked)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");


            if (moveHorizontal != 0 || moveVertical != 0)
            {
                //Vector3 movement = transform.position + new Vector3(moveHorizontal, 0, moveVertical) * speedFactor;
                //rigidbody.MovePosition(movement);

                //GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized * speedFactor);

                //mathf.clamp(forceadded, min, max);
                //Vector3 movement = transform.position + new Vector3(moveHorizontal, 0, moveVertical) * speedFactor;

                //rigidbody.AddForce(Mathf.Clamp(moveHorizontal * speedFactor, -20, 20), 0, Mathf.Clamp(moveVertical * speedFactor, -20, 20));
                rigidbody.velocity += new Vector3(moveHorizontal, 0, moveVertical) * playerAcceleration;
                if (rigidbody.velocity.magnitude > maxSpeed)
                {
                    rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
                }
                //rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);

            }
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
        canvas.healthText.text = currentHealth.ToString();
    }

    public void ReceiveDamage(float damageValue)
    {
        currentHealth -= damageValue;

        damageParticles.Play();
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        canvas.healthText.text = currentHealth.ToString();
        Debug.Log(currentHealth);
    }

    

}
