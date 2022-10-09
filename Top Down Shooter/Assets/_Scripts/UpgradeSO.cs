using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class UpgradeSO : ScriptableObject
{
    [Header("Attributes")]
    public string upgradeName;
    public int[] prices;
    public float[] effectors;
    public int[] unlockLevels;
}
