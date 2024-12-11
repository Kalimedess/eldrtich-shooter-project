using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target != null)
        {

            Vector2 direction = (target.position - transform.position).normalized;


            rb.linearVelocity = direction * moveSpeed;


            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
        else
        {

            rb.linearVelocity = Vector2.zero;
        }
    }
}
