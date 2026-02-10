using UnityEngine;

public class EnemyPaddle : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject ball;
    public SpriteRenderer spriteRenderer;

    public float speed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball");

        spriteRenderer.color = SaveController.Instance.enemyColor;
    }

    void Update()
    {
        if (ball != null)
        {
            float targetY = Mathf.Clamp(ball.transform.position.y, -3.7f, 3.7f);
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
