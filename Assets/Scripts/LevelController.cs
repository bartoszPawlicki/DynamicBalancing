using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public bool levelStarted = false;
    public bool levelFinished = false;

    public List<DoorController> doors;
    public List<EnemyController> enemies;
    public LevelController nextLevel;
	void Start ()
    {

    }
	
	void Update ()
    {
        if(!levelFinished)
        {
            bool allEnemiesDestroyed = true;
            foreach (EnemyController enemy in enemies)
            {
                if (enemy.gameObject.activeSelf)
                {
                    allEnemiesDestroyed = false;
                    break;
                }
            }

            if (allEnemiesDestroyed)
            {
                FinishLevel();
            }
        }
        
	}

    public void StartLevel()
    {
        levelStarted = true;

        foreach (DoorController door in doors)
        {
            door.CloseDoor();
        }
    }

    public void FinishLevel()
    {
        levelFinished = true;

        foreach (DoorController door in doors)
        {
            door.OpenDoor();
        }

        foreach (DoorController door in nextLevel.doors)
        {
            door.OpenDoor();
        }

    }
}
