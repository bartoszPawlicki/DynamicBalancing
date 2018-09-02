using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void MoveCameraToPosition(Vector3 destination)
    {
        transform.position = destination;
    }
    
}
