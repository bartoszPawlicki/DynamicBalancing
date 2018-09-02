using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterTriggerController : MonoBehaviour
{
    public LevelController parentLevel;
    void Start()
    {

    }
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            parentLevel.StartLevel();
        }
    }
}
