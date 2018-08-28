using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;

    [SerializeField] GameObject pinPrefab;
    [SerializeField] GameObject ball;

    bool gameOver = false;
    bool levelComplete = false;
    int pinNumber;
    int currentLevel;

    void Awake() // singleton design pattern
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        SetLevelSettings();
        UIManager.singleton.ScoreText = pinNumber;
        UIManager.singleton.LevelText = currentLevel;
    }

    public void GameOver()
    {
        if (levelComplete)
            return;
        gameOver = true;
        SoundManager.singleton.PlayGameover();
        Camera.main.backgroundColor = Color.red;
        UIManager.singleton.EnableMenuUI(false);
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public bool IsLevelComplete()
    {
        return levelComplete;
    }

    public void IncreasePlayerScore()
    {
        if (gameOver)
            return;
        pinNumber--;
        UIManager.singleton.ScoreText = pinNumber;
        SoundManager.singleton.PlayStrike();
        if (pinNumber == 0)
            LevelComplete();
    }

    void LevelComplete()
    {
        levelComplete = true;
        Camera.main.backgroundColor = Color.green;
        LevelManager.singleton.IncreaseParameters();
        UIManager.singleton.EnableMenuUI(true);
    }

    void SetLevelSettings()
    {
        pinPrefab.GetComponent<Pin>().Speed = LevelManager.singleton.PinSpeed;
        ball.GetComponent<Ball>().RotationSpeed = LevelManager.singleton.BallRotationSpeed;
        pinNumber = LevelManager.singleton.PinNumber;
        currentLevel = LevelManager.singleton.Level;
    }

    public GameObject PinPrefab
    {
        get
        {
            return pinPrefab;
        }
    } 

    void LoadLevel() // used to delay the reload of the scene
    {
        SceneManager.LoadScene("GameScene");
    }

    public void RestartCurrentLevel()
    {
        LoadLevel();
    }

    public void RestartLevelToOne()
    {
        LevelManager.singleton.ResetGame();
        LoadLevel();
    }

}
