using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager singleton;

    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    [SerializeField] Toggle audioToggle;
    [SerializeField] GameObject levelEndMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject menuButton;
 
    void Awake() // singleton design pattern
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        levelEndMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void EnableLevelEndMenuUI(bool isLevelComplete)
    {
        levelEndMenu.SetActive(true);
        menuButton.SetActive(false);
        if (isLevelComplete)
            levelEndMenu.GetComponent<LevelEndMenuUI>().SetText("NEXT LEVEL");
        else
            levelEndMenu.GetComponent<LevelEndMenuUI>().SetText("RETRY LEVEL");
    }

    public void TogglePauseMenuUI()
    {
        if (!pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    public Toggle AudioToggle
    {
        get
        {
            return audioToggle;
        }
    }

    public int ScoreText
    {
        set
        {
            scoreText.text = value.ToString();
        }
    }

    public int LevelText
    {
        set
        {
            levelText.text = "Level " + value;
        }
    }

    public void RestartLevel() // called from Retry Button
    {
        GameManager.singleton.RestartCurrentLevel();
    }

    public void ResetGame() // called from Reset Game Button
    {
        GameManager.singleton.RestartLevelToOne();
    }

    public void Quit()
    {
        GameManager.singleton.Quit();
    }

}
