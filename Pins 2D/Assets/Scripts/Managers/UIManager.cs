using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager singleton;

    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    [SerializeField] Toggle audioToggle;
    [SerializeField] GameObject menu;
 
    void Awake() // singleton design pattern
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        menu.SetActive(false);    
    }

    public void EnableMenuUI(bool isLevelComplete)
    {
        menu.SetActive(true);
        if (isLevelComplete)
            menu.GetComponent<MenuUI>().SetText("NEXT LEVEL");
        else
            menu.GetComponent<MenuUI>().SetText("RETRY LEVEL");
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

}
