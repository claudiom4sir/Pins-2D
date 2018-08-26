using UnityEngine;

public class Pin : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] float speed = 5f;
    bool targetReached = false;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void FixedUpdate()
    {
        if (targetReached)
            return;
        rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
    }


    void OnTriggerEnter2D(Collider2D other) // when pin touchs something
    {
        if(other.tag == "Ball")
        {
            transform.SetParent(target);
            targetReached = true;
            enabled = false;
        }
        
    }

}
