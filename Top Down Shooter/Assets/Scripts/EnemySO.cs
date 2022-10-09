using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    [Header("Stats")]
    public float speed;
    public int health;

    [Header("Money")]
    public int moneyValue;
    public int longRangeBonus;
    public int mediumRangeBonus;

    [Header("Behaviour")]
    public float spinSpeed;
}
