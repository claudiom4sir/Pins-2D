using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsSpawn : MonoBehaviour {

    GameObject pin;
    GameObject currentPin = null;

    void Start()
    {
        pin = GameManager.singleton.PinPrefab;    
    }

    void Update()
    {
        if (GameManager.singleton.IsGameOver() || GameManager.singleton.IsLevelComplete())
            return;
        if (PinManager.singleton.ExistsPinInMovement())
            return;
        if (currentPin == null)
            CreatePin();
        if (Input.GetKeyDown(KeyCode.Space) && currentPin != null) // used on pc, on android mobile is used OnMouseDown
            StartMovePin();
    }

    private void OnMouseDown() // used as a touch in android mobile
    {
        if (currentPin == null)
            return;
        StartMovePin();
    }

    void CreatePin()
    {
        GameObject _pin = Instantiate(pin, transform.position, Quaternion.identity);
        currentPin = _pin;
        _pin.GetComponent<Pin>().enabled = false;
    }

    void StartMovePin()
    {
        PinManager.singleton.SetPinInMoviment(true);
        currentPin.GetComponent<Pin>().enabled = true;
        currentPin = null;
    }

}
