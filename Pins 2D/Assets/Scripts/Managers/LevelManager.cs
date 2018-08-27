using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager singleton;

    static float pinSpeed = 5f;
    static float ballRotationSpeed = 50f;
    static int pinNumber = 5;
    static int level = 1;

    void Awake() // singleton design pattern
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
    }

    public void IncreaseParameters()
    {
        level++;
        pinSpeed = pinSpeed * 1.25f;
        ballRotationSpeed = ballRotationSpeed * 1.25f;
        pinNumber = pinNumber + 2;
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

}
