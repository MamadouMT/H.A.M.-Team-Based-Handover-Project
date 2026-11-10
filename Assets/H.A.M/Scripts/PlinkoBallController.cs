using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlinkoBallController : MonoBehaviour
{
    public float minX = -4f;
    public float maxX = 4f;
    public float respawnDelay = 1.5f;

    public GameObject portalExit;
    public GameObject portal2Exit;
    
    private Rigidbody2D rb;
    private Camera cam;
    private bool dropped = false;

    private Vector3 startingPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        startingPosition = transform.position;

        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        if (dropped) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldPosition = cam.ScreenToWorldPoint(mousePosition);

        float newX = Mathf.Clamp(worldPosition.x, minX, maxX);

        transform.position = new Vector3(
            newX,
            transform.position.y,
            transform.position.z
        );

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            dropped = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void Respawn()
    {
        StartCoroutine(RespawnAfterDelay());
    }

    IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);

        rb.bodyType = RigidbodyType2D.Kinematic;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        transform.position = startingPosition;
        transform.rotation = Quaternion.identity;

        dropped = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Portal"))
        {
            transform.position = portalExit.transform.position;

        }
    }
}