using UnityEngine;
using UnityEngine.UI;

public class LevelEndMenuUI : MonoBehaviour {

    [SerializeField] Text retry_goAHead; // it's the text of Retry Button, because it is able to became like NextLevel Button

    public void SetText(string text)
    {
        retry_goAHead.text = text;
    }

}
