using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public LevelController startingLevel;
    
	void Start ()
    {
        

	}

    public void StartGame()
    {
        startingLevel.StartLevel(DoorController.DoorLocation.RIGHT);
    }
	
	void Update ()
    {
		
	}
}
