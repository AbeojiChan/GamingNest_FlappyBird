using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [Header("Speed Settings")]
    public float speed = 2f;
    public float speedIncrease = 0.1f;
    public float maxSpeed = 20f;
    public float destroyX = -14f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        speed += speedIncrease * Time.deltaTime;
        speed = Mathf.Min(speed, maxSpeed);

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
