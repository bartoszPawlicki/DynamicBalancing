using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public bool levelStarted = false;
    public bool levelFinished = false;

    public List<DoorController> doors;
    public List<EnemyController> enemies;
	void Start ()
    {

    }
	
	void Update ()
    {
		
	}

    public void StartLevel()
    {
        levelStarted = true;

        foreach (DoorController door in doors)
        {
            door.open = false;
        }
    }

    public void FinishLevel()
    {
        levelFinished = true;

        foreach (DoorController door in doors)
        {
            door.open = true;
        }
    }
}
