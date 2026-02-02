using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2f;
    public float destroyX = -10f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
