using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float minSpeed = 2f;
    public float maxSpeed = 5f;

    public int direction = 1;

    private float moveSpeed;

    void Start()
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPosition.x < -0.1f || screenPosition.x > 1.1f)
        {
            Destroy(gameObject);
        }
    }
}