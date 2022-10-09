using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("In-Game Stats")]
    public int health = 1;
    public int progressCounter;

    [Header("Game State")]
    public bool gameOver = false;
    bool wonLevel = false;

    [Header("UI")]
    public Text moneyText;
    public Slider progressBar;
    public Text levelText;
    public Text rewardMoneyText;

    [Header("Components")]
    public LevelSO[] levels;
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public GameObject pauseMenuPanel;
    public GameObject joystick;
    public WaveSpawner waveSpawner;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1;
        levelText.text = "LEVEL " + PlayerStats.Instance.currentLevel;
    }

    void Update()
    {
        moneyText.text = PlayerStats.Instance.money.ToString();
        progressBar.value = progressCounter;

        if(!wonLevel && progressCounter == waveSpawner.level.numberOfEnemies)
        {
            wonLevel = true;
            Invoke("WinGame", 1f);
        }

        if (health <= 0)
        {
            health = 0;
            EndGame();
        }
    }

    void EndGame()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        joystick.SetActive(false);
    }

    public void WinGame()
    {
        gameOver = true;
        levelCompletePanel.SetActive(true);
        joystick.SetActive(false);
        rewardMoneyText.text = levels[PlayerStats.Instance.currentLevel - 1].completionReward.ToString();
        PlayerStats.Instance.money += levels[PlayerStats.Instance.currentLevel - 1].completionReward;
        PlayerStats.Instance.currentLevel++;
    }

    public void OpenPauseMenu()
    {
        pauseMenuPanel.SetActive(true);
        joystick.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        joystick.SetActive(true);
        Time.timeScale = 1;
    }
}
