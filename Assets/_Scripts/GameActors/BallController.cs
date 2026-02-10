using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private Rigidbody2D rb;
    public Vector2 startingVelocity = new(5f,5f);
    public float speedUp = 1.1f;

    public void ResetBall()
    {
        transform.position = Vector2.zero;

        if (rb == null ) rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = startingVelocity;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -rb.linearVelocity.y);
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x, rb.linearVelocity.y);
            rb.linearVelocity *= speedUp;
        }
        else if (collision.gameObject.CompareTag("WallPlayer"))
        {
            gameManager.ScoreEnemy();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("WallEnemy"))
        {
            gameManager.ScorePlayer();
            ResetBall();
        }
    }
}
