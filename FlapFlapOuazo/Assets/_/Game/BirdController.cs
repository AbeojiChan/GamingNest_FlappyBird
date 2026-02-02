using UnityEngine;

public class BirdController : MonoBehaviour
{

    public enum GameState
    {
        Playing,
        GameOver
    }

   
    public GameState currentState = GameState.Playing;

    [Header("Bird Settings")]
    [Range(1f, 10f)]
    public float jumpForce = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Bird Ready");
    }

    void Update()
    {
        if (currentState != GameState.Playing)
            return;

        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            currentState = GameState.GameOver;
            Debug.Log("Game Over");
        }
    }
}
