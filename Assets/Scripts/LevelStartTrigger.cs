using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartTrigger : MonoBehaviour
{
    public LevelController parentLevel;
	void Start ()
    {
		
	}
	void Update ()
    {
		
	}

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            parentLevel.StartLevel();
        }
    }
}
