using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {

        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");


        Vector2 movement = new Vector2(speedX, speedY);


        if (movement.magnitude > 1f)
        {
            movement = movement.normalized;
        }


        rb.linearVelocity = movement * movSpeed;


        Debug.Log(rb.linearVelocity);
    }
}
