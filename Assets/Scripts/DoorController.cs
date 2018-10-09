using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool open = false;
    public LevelController parentLevel;
    public DoorController nextRoomDoor;

    public enum DoorLocation
    {
        UP, DOWN, LEFT, RIGHT
    }

    public DoorLocation doorLocation;

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
        if(doorLocation == DoorLocation.DOWN)
        {

        }
    }
    public void CloseDoor()
    {
        transform.position += Vector3.down * 3;
        open = false;
    }
}
