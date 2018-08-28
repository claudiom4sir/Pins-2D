using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager singleton;

    static float pinSpeed;
    static float ballRotationSpeed;
    static int pinNumber;
    static int level = 1;

    [SerializeField] float levelOnePinSpeed = 5f;
    [SerializeField] float levelOneBallRotationSpeed = 50f;
    [SerializeField] int levelOnePinNumber = 5;

    void Awake() // singleton design pattern
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        ReadParameters();  
    }

    void ReadParameters() // it reads the parameters from PlayerPrefs
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            pinSpeed = PlayerPrefs.GetFloat("PinSpeed");
            ballRotationSpeed = PlayerPrefs.GetFloat("BallRotationSpeed");
            pinNumber = PlayerPrefs.GetInt("PinNumber");
            level = PlayerPrefs.GetInt("Level");
        }
        else
        {
            SetParametersLevelOne();
            WriteParametersFirstTime();

        }
    }

    void SetParametersLevelOne() // it sets the parameters in the level one
    {
        pinSpeed = levelOnePinSpeed;
        ballRotationSpeed = levelOneBallRotationSpeed;
        pinNumber = levelOnePinNumber;
        level = 1;
    }

    void WriteParametersFirstTime() // like WriteParameters, but only after level one
    {
        PlayerPrefs.SetFloat("PinSpeed", pinSpeed);
        PlayerPrefs.SetFloat("BallRotationSpeed", ballRotationSpeed);
        PlayerPrefs.SetInt("PinNumber", pinNumber);
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();
    }

    void WriteParameters() // writes parameters in PlayerPrefs
    {
        if (PlayerPrefs.HasKey("Level") && PlayerPrefs.GetInt("Level") < level)
        {
            PlayerPrefs.SetFloat("PinSpeed", pinSpeed);
            PlayerPrefs.SetFloat("BallRotationSpeed", ballRotationSpeed);
            PlayerPrefs.SetInt("PinNumber", pinNumber);
            PlayerPrefs.SetInt("Level", level);
            PlayerPrefs.Save();
        }
    }

    public void IncreaseParameters()
    {
        level++;
        pinSpeed = pinSpeed * 1.25f;
        ballRotationSpeed = ballRotationSpeed * 1.25f;
        pinNumber = pinNumber + 2;
        WriteParameters();
    }

    public float PinSpeed
    {
        get
        {
            return pinSpeed;
        }
    }

    public float BallRotationSpeed
    {
        get
        {
            return ballRotationSpeed;
        }
    }

    public int PinNumber
    {
        get
        {
            return pinNumber;
        }
    }

    public int Level {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    public void ResetGame() // used to destroy all keys in PlayerPrefs
    {
        PlayerPrefs.DeleteAll();
    }

}
