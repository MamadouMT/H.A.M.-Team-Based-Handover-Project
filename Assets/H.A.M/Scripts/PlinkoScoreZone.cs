using UnityEngine;

public class PlinkoScoreZone : MonoBehaviour
{
    public int points = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("You scored " + points + " points!");

            PlinkoBallController ball =
                other.GetComponent<PlinkoBallController>();

            if (ball != null)
            {
                ball.Respawn();
            }
        }
    }
}