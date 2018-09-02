using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public bool levelStarted = false;
    public bool levelFinished = false;

    public List<GameObject> walls;
    public List<DoorController> doors;
    public List<EnemyController> enemies;

    public List<GameObject> levelContents;


    public LevelController nextLevel;

	void Start ()
    {
        //foreach (GameObject go in transform.GetChild(0).transform.ge)
        //{
        //    walls.Add(go);
        //}

        foreach (DoorController door in doors)
        {
            door.gameObject.GetComponentInChildren<DoorEnterTriggerController>().parentLevel = this;
        }
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
