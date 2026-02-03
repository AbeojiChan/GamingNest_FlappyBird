using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<ScoreManager>().AddPoint();

            Debug.Log("Bird Inside");
        }
    }
}
