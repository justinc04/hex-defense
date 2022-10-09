using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class LevelSO : ScriptableObject
{
    public float initialDelay;
    public int completionReward;
    public int numberOfEnemies;
    public GameObject[] enemyTypes;
    public int[] spawnChance;
    public float enemyDelay;
}
