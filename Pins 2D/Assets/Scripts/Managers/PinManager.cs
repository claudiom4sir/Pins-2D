using UnityEngine;

public class PinManager : MonoBehaviour {

    public static PinManager singleton;
    bool existsPinInMoviment = false; // if it's true, PinsSpawn can't spawn another pin

    void Awake() // singleton design pattern
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
            Destroy(gameObject);
    }

    public void SetPinInMoviment(bool value)
    {
        existsPinInMoviment = value;
    }

    public bool ExistsPinInMovement()
    {
        return existsPinInMoviment;
    }

}
