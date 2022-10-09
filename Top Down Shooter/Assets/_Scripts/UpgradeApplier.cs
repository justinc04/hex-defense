using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeApplier : MonoBehaviour
{
    public UpgradeSO upgrade;

    public void PurchaseUpgrade()
    {
        PlayerStats.Instance.money -= upgrade.prices[PlayerStats.Instance.upgradeLevels[upgrade.upgradeName]];
        ApplyUpgrade();

        PlayerStats.Instance.upgradeLevels[upgrade.upgradeName]++;
        ShopManager.Instance.RefreshShop();
    }

    void ApplyUpgrade()
    {
        switch(upgrade.upgradeName)
        {
            case "Rate of Fire":
                PlayerStats.Instance.reload = upgrade.effectors[PlayerStats.Instance.upgradeLevels[upgrade.upgradeName]];
                break;
            case "Damage":
                PlayerStats.Instance.bulletDamage = (int)upgrade.effectors[PlayerStats.Instance.upgradeLevels[upgrade.upgradeName]];
                break;
            case "Barrels":
                PlayerStats.Instance.barrels = (int)upgrade.effectors[PlayerStats.Instance.upgradeLevels[upgrade.upgradeName]];
                break;
            case "Shield":
                if(PlayerStats.Instance.upgradeLevels[upgrade.upgradeName] == 0)
                {
                    PlayerStats.Instance.shield = true;
                }

                PlayerStats.Instance.shieldRegenTime = upgrade.effectors[PlayerStats.Instance.upgradeLevels[upgrade.upgradeName]];
                break;
        }
    }
}
