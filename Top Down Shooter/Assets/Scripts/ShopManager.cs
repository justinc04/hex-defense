using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    public GameObject mainWeaponPanel;
    public GameObject specialsPanel;

    public Text moneyText;
    public UpgradeSO[] upgrades;
    public Button[] upgradeButtons;

    public Dictionary<string, Button> upgradeButtonNames;
    public Dictionary<string, Text> priceTextNames;
    public Dictionary<string, Text> upgradeLevelTextNames;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        upgradeButtonNames = new Dictionary<string, Button>();
        priceTextNames = new Dictionary<string, Text>();
        upgradeLevelTextNames = new Dictionary<string, Text>();

        for(int i = 0; i < upgrades.Length; i++)
        {
            upgradeButtonNames.Add(upgrades[i].upgradeName, upgradeButtons[i]);
            priceTextNames.Add(upgrades[i].upgradeName, upgradeButtons[i].transform.Find("PriceText").GetComponent<Text>());
            upgradeLevelTextNames.Add(upgrades[i].upgradeName, upgradeButtons[i].transform.Find("UpgradeLevelText").GetComponent<Text>());
        }

        RefreshShop();
    }

    public void RefreshShop()
    {
        moneyText.text = PlayerStats.Instance.money.ToString();

        foreach (UpgradeSO upgrade in upgrades)
        {
            upgradeLevelTextNames[upgrade.upgradeName].text = PlayerStats.Instance.upgradeLevels[upgrade.upgradeName] + "/" + upgrade.prices.Length;

            if (PlayerStats.Instance.upgradeLevels[upgrade.upgradeName] == upgrade.prices.Length)
            {
                upgradeButtonNames[upgrade.upgradeName].interactable = false;
                priceTextNames[upgrade.upgradeName].text = "MAX LEVEL";
            }
            else if (PlayerStats.Instance.money < upgrade.prices[PlayerStats.Instance.upgradeLevels[upgrade.upgradeName]])
            {
                upgradeButtonNames[upgrade.upgradeName].interactable = false;
                priceTextNames[upgrade.upgradeName].text = upgrade.prices[PlayerStats.Instance.upgradeLevels[upgrade.upgradeName]].ToString();
            }
            else
            {
                upgradeButtonNames[upgrade.upgradeName].interactable = true;
                priceTextNames[upgrade.upgradeName].text = upgrade.prices[PlayerStats.Instance.upgradeLevels[upgrade.upgradeName]].ToString();
            }
        }
    }

    public void OpenMainWeaponPanel()
    {
        mainWeaponPanel.SetActive(true);
    }

    public void OpenSpecialsPanel()
    {
        specialsPanel.SetActive(true);
    }

    public void BackToShop()
    {
        SceneManager.LoadScene(1);
    }    
}
