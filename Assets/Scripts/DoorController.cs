using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool open = false;
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void OpenDoor()
    {
        transform.position += Vector3.up * 3;
        open = true;
    }
    public void CloseDoor()
    {
        transform.position += Vector3.down * 3;
        open = false;
    }
}
