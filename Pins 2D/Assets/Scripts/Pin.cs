using UnityEngine;

public class Pin : MonoBehaviour {

    [SerializeField] GameObject target;
    [SerializeField] float speed = 5f;
    bool targetReached = false;
    Rigidbody2D rb;

    void Start()
    {
        target = GameObject.FindWithTag("Ball"); // used because i can't drag Ball transform in pin prefab
        rb = GetComponent<Rigidbody2D>();    
    }

    void FixedUpdate()
    {
        if (targetReached || GameManager.singleton.IsGameOver())
            return;
        rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    void OnTriggerEnter2D(Collider2D other) // when pin touchs something
    {
        if (other.tag == "Ball")
        {
            targetReached = true;
            transform.SetParent(target.transform);
            PinManager.singleton.SetPinInMoviment(false);
            GameManager.singleton.IncreasePlayerScore();
            enabled = false;
        }
        else if (other.tag == "Pin")
        {
            if(!GameManager.singleton.IsGameOver())
            GameManager.singleton.GameOver();
        }
    }

}
