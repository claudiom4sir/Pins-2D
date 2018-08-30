using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour {

    public void RestartLevel() // called from Retry Button
    {
        GameManager.singleton.RestartCurrentLevel();
    }

}
