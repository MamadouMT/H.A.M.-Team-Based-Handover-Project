using UnityEngine;
using System.Collections;

public class TomatoProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float splatDelay = 0.5f;
    public Sprite splatSprite;

    private Vector3 targetPosition;
    private bool hasTarget;
    private bool hasHit;

    public void Launch(Vector3 target)
    {
        targetPosition = target;
        hasTarget = true;
    }

    void Update()
    {
        if (!hasTarget || hasHit)
            return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            hasTarget = false;
            StartCoroutine(Splat());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit)
            return;

        if (other.CompareTag("Enemy"))
        {
            hasHit = true;
            hasTarget = false;

            Destroy(other.gameObject);

            StartCoroutine(Splat());
        }
    }

    IEnumerator Splat()
    {
        hasHit = true;

        GetComponent<SpriteRenderer>().sprite = splatSprite;

        // Disable collider so the splat cannot hit anything else
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(splatDelay);

        Destroy(gameObject);
    }
}