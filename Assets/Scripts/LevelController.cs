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

    public List<GameObject> enemiesPrefabs;

    public ObjectPool meatClotPool;
    public ObjectPool fatEnemyPool;
    public List<float> enemySpawnWeights = new List<float>() { 0.8f, 0.2f };
    public int enemiesCount = 5;

    public List<GameObject> levelContents;


    public LevelController nextLevel;

    public bool delayOnLevelStartFinished = false;
    public float delayOnLevelStartFinishedTimer = 2f;

    public List<GameObject> rewardPrefabs;

    public BalancingSystem balancingSystem;

    public List<Transform> spawnPoints;

	void Start ()
    {
        foreach (DoorController door in doors)
        {
            door.parentLevel = this;
        }
        balancingSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<BalancingSystem>();
    }

    public void SpawnRandomEnemies()
    {
        switch (balancingSystem.difficulty)
        {
            case BalancingSystem.Difficulty.easy:
                float spawnWeight = ((balancingSystem.grade) * 0.02f);
                enemySpawnWeights = new List<float>() { 1f - spawnWeight, spawnWeight };
                break;

            case BalancingSystem.Difficulty.medium:
                float spawnWeight2 = ((balancingSystem.grade ) * 0.04f - 0.1f);
                enemySpawnWeights = new List<float>() { 1f - spawnWeight2, spawnWeight2 };
                break;

            case BalancingSystem.Difficulty.hard:
                float spawnWeight3 = ((balancingSystem.grade) * 0.04f - 0.1f);
                enemySpawnWeights = new List<float>() { 1f - spawnWeight3, spawnWeight3 };
                break;
        }

        for (int i=0; i<enemiesCount; i++)
        {
            int rand = BalancingSystem.RandomWithWeight(enemySpawnWeights);

            if(rand == 0)
            {
                GameObject enemy = meatClotPool.PoolNext(spawnPoints[0].position);
                spawnPoints.RemoveAt(0);
                enemy.transform.parent = transform.Find("Enemies");
                enemies.Add(enemy.GetComponentInChildren<MeatClot>());
            }
            else if(rand == 1)
            {
                GameObject enemy = fatEnemyPool.PoolNext(spawnPoints[0].position);
                spawnPoints.RemoveAt(0);
                enemy.transform.parent = transform.Find("Enemies");
                enemies.Add(enemy.GetComponentInChildren<FatEnemy>());
            }
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

            if (allEnemiesDestroyed && levelStarted)
            {
                FinishLevel();
            }
        }
        if(levelStarted)
        {
            delayOnLevelStartFinishedTimer -= Time.deltaTime;
            if(delayOnLevelStartFinishedTimer <= 0 && !delayOnLevelStartFinished)
            {
                delayOnLevelStartFinished = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().locked = false;
            }
        }
        
	}

    public void StartLevel(DoorController.DoorLocation exitDoorLocation)
    {
        
        levelStarted = true;
        
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCamera>().MoveCameraToPosition(transform.position - GlobalConstants.CameraLevelOffset);
        Vector3 teleportPosition = Vector3.zero;

        switch (exitDoorLocation)
        {
            case (DoorController.DoorLocation.DOWN):
                teleportPosition = transform.position + 8 * Vector3.forward;
                break;
            case (DoorController.DoorLocation.UP):
                teleportPosition = transform.position + 8 * Vector3.back;
                break;
            case (DoorController.DoorLocation.LEFT):
                teleportPosition = transform.position + 8 * Vector3.right;
                break;
            case (DoorController.DoorLocation.RIGHT):
                teleportPosition = transform.position + 8 * Vector3.left;
                break;
        }
        
        GameObject.FindGameObjectWithTag("Player").transform.position = teleportPosition;

        if (!levelFinished)
        {
            SpawnRandomEnemies();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().locked = true;
            foreach (DoorController door in doors)
            {
                door.CloseDoor();
            }
            balancingSystem.StartGrading();
        }

        foreach (EnemyController ec in enemies)
        {
            ec.DifficultyUpdate();
        }

        

    }

    public void FinishLevel()
    {
        levelFinished = true;
        SpawnEndLevelReward();

        foreach (DoorController door in doors)
        {
            door.OpenDoor();
        }

        balancingSystem.EndGrading();

    }

    public void SpawnEndLevelReward()
    {
        List<float> endRewardWeights = new List<float>() { 0.7f, 0.2f, 0.1f };
        float oneHeart = 0;
        float twoHearts = 0;
        float threeHearts = 0;

        switch (balancingSystem.difficulty)
        {
            case BalancingSystem.Difficulty.easy:
                oneHeart = (0.2f + (balancingSystem.grade - 1) * 0.075f);
                twoHearts = (0.4f - (balancingSystem.grade - 1) * 0.025f);
                threeHearts = (0.4f - (balancingSystem.grade - 1) * 0.05f);
                endRewardWeights = new List<float>() { oneHeart, twoHearts, threeHearts };
                break;

            case BalancingSystem.Difficulty.medium:
                oneHeart = (0.5f + (balancingSystem.grade - 5) * 0.05f);
                twoHearts = (0.3f - (balancingSystem.grade - 5) * 0.025f);
                threeHearts = (0.2f - (balancingSystem.grade - 5) * 0.025f);
                endRewardWeights = new List<float>() { oneHeart, twoHearts, threeHearts };
                break;

            case BalancingSystem.Difficulty.hard:
                oneHeart = (0.7f + (balancingSystem.grade - 9) * 0.05f);
                twoHearts = (0.2f - (balancingSystem.grade - 9) * 0.025f);
                threeHearts = (0.1f - (balancingSystem.grade - 9) * 0.025f);
                endRewardWeights = new List<float>() { oneHeart, twoHearts, threeHearts };
                break;
        }
        //int rand = Random.Range(0, rewardPrefabs.Count);

        GameObject go = Instantiate(rewardPrefabs[BalancingSystem.RandomWithWeight(endRewardWeights)], transform);
        go.transform.localPosition = new Vector3(0, -0.8f, 0);
    }
}
