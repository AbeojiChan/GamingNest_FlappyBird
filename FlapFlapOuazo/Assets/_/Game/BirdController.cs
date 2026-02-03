using UnityEngine;
using TMPro;
using System.Collections;

public class BirdController : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deathSound;

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
    }

    void Update()
    {
        if (currentState == GameState.GameOver)
        {
            transform.Rotate(0f, 0f, 200f * Time.deltaTime);
            return;
        }

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

        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFX(jumpSound);
    }

    public void Die()
    {
        if (currentState == GameState.GameOver)
            return;

        currentState = GameState.GameOver;

        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFX(deathSound);

        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 16f, ForceMode2D.Impulse);

        rb.gravityScale = 3f;
        rb.constraints = RigidbodyConstraints2D.None;

        enabled = false;

        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        StartCoroutine(FreezeAfterDelay());
    }

    IEnumerator FreezeAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }
}
