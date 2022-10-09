using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [HideInInspector]
    public LevelSO level;

    public Transform spawnArea;

    bool canSpawn = false;
    float enemyCounter;
    GameObject enemyToSpawn;

    void Start()
    {
        level = GameManager.Instance.levels[PlayerStats.Instance.currentLevel - 1];
        GameManager.Instance.progressBar.maxValue = level.numberOfEnemies;

        Invoke("StartLevel", level.initialDelay);
    }

    void Update()
    {
        if (enemyCounter < level.numberOfEnemies && canSpawn && !GameManager.Instance.gameOver)
        {
            StartCoroutine(SpawnWave());
        }
    }

    void StartLevel()
    {
        canSpawn = true;
    }

    IEnumerator SpawnWave()
    {
        canSpawn = false;
        enemyCounter++;

        int chanceNumber = Random.Range(1, 101);
        int chanceSum = 0;

        for (int i = 0; i < level.enemyTypes.Length; i++)
        {
            chanceSum += level.spawnChance[i];
            if (chanceNumber <= chanceSum)
            {
                enemyToSpawn = level.enemyTypes[i];
                break;
            }
        }

        Vector2 spawnPos = RandomCircle(Vector2.zero, spawnArea.localScale.x / 2f);
        Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(level.enemyDelay);

        canSpawn = true;
    }

    Vector2 RandomCircle(Vector2 center, float radius)
    {
        float ang = Random.value * 360;
        Vector2 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
