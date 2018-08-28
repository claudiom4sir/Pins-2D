using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    public static SoundManager singleton;
    [SerializeField] AudioSource background;
    [SerializeField] AudioSource strike;
    [SerializeField] AudioSource gameover;
    bool isAudioEnabled = false;

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject); // used to do not stop the music between scenes
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        isAudioEnabled = UIManager.singleton.AudioToggle.isOn;    
    }

    public void PlayStrike()
    {
        if (isAudioEnabled)
            strike.Play();
    }

    public void PlayGameover()
    {
        if (isAudioEnabled)
            gameover.Play();
    }

    public bool IsAudioEnabled
    {
        set
        {
            isAudioEnabled = value;
            if (value == false)
                StopAllAudio();
            else
                PlayBackground();
        }
    }

    void PlayBackground()
    {
        if (isAudioEnabled)
            background.Play();
    }

    void StopAllAudio()
    {
        background.Stop();
        strike.Stop();
        gameover.Stop();
    }

}
