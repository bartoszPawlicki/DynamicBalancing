﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float startHealth;

    private float currentHealth;
	void Start ()
    {
        currentHealth = startHealth;
	}
	
	void Update ()
    {
		
	}

    public void ReceiveDamage(float damageValue)
    {
        currentHealth -= damageValue;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}