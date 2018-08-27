using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;

    [SerializeField] GameObject pinPrefab;
    [SerializeField] GameObject ball;
    [SerializeField] float timeBeforeLoad = 3f;

    bool gameOver = false;
    bool levelComplete = false;
    int pinNumber;
    int currentLevel = 1;

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
        gameOver = true;
        Camera.main.backgroundColor = Color.red;
        StartCoroutine(LoadLevel());
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
        pinNumber--;
        UIManager.singleton.ScoreText = pinNumber;
        if (pinNumber == 0)
            LevelComplete();
    }

    void LevelComplete()
    {
        levelComplete = true;
        Camera.main.backgroundColor = Color.green;
        LevelManager.singleton.IncreaseParameters();
        StartCoroutine(LoadLevel());
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

    IEnumerator LoadLevel() // used to delay the reload of the scene
    {
        yield return new WaitForSeconds(timeBeforeLoad);
        SceneManager.LoadScene("GameScene");
    }

}
