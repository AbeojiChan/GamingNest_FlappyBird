using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            scoreManager.AddPoint();
        }
    }
}
