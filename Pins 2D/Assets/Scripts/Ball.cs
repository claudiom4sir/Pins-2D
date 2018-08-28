using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] float rotationSpeed;

    void Update()
    {
        if (GameManager.singleton.IsGameOver() || GameManager.singleton.IsLevelComplete())
            return;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    public float RotationSpeed
    {
        set
        {
            rotationSpeed = value;
        }
    }

}
