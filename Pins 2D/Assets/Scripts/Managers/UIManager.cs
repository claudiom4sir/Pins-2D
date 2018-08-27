using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager singleton;

    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;

    void Awake() // singleton design pattern
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
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

}
