using UnityEngine.UI;
using UnityEngine;

public class AudioToggle : MonoBehaviour {

    [SerializeField] Toggle toggle;

    public void Toggle()
    {
        SoundManager.singleton.IsAudioEnabled = toggle.isOn;
    }

}
