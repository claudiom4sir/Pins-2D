using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] float rotationSpeed = 20f;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

}
