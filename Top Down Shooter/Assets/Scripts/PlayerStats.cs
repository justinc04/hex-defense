using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [Header("Main Weapon Stats")]
    public int money;
    public int currentLevel;
    public float reload = .8f;
    public int bulletPierce = 1;
    public int bulletDamage = 1;
    public float bulletSize = .1f;
    public float bulletSpeed = 2f;
    public int barrels = 1;

    [Header("Special Stats")]
    public bool shield = false;
    public float shieldRegenTime;

    [Header("Upgrades")]
    public UpgradeSO[] upgrades;
    public Dictionary<string, int> upgradeLevels;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        upgradeLevels = new Dictionary<string, int>();

        foreach(UpgradeSO upgrade in upgrades)
        {
            upgradeLevels.Add(upgrade.upgradeName, 0);
        }
    }
}


