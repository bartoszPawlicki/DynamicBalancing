using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterTriggerController : MonoBehaviour
{
    
    
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
            GetComponentInParent<DoorController>().nextRoomDoor.parentLevel.StartLevel(GetComponentInParent<DoorController>().doorLocation);
        }
    }
}
