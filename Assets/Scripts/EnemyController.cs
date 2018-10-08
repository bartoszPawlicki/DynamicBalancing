using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    protected float startHealth;
    protected PlayerController playerController;
    
    public BalancingSystem balancingSystem;

    protected float currentHealth;
	void Start ()
    {
        
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

    public virtual void DifficultyUpdate()
    {

    }
}
