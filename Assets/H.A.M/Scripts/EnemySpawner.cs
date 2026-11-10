using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] rightFacingPrefabs;
    public GameObject[] leftFacingPrefabs;

    public float spawnInterval = 2f;
    public float spawnHeightMin = -4f;
    public float spawnHeightMax = 4f;
    public float spawnDistance = 1f;

    public void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        bool spawnRightFacing = Random.Range(0, 2) == 0;

        GameObject[] selectedPrefabs = spawnRightFacing
            ? rightFacingPrefabs
            : leftFacingPrefabs;

        if (selectedPrefabs.Length == 0)
            return;

        int randomIndex = Random.Range(0, selectedPrefabs.Length);

        float randomY = Random.Range(spawnHeightMin, spawnHeightMax);

        float leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        float rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right).x;

        float spawnX;
        int direction;

        if (spawnRightFacing)
        {
            spawnX = leftEdge - spawnDistance;
            direction = 1;
        }
        else
        {
            spawnX = rightEdge + spawnDistance;
            direction = -1;
        }

        GameObject enemy = Instantiate(
            selectedPrefabs[randomIndex],
            new Vector3(spawnX, randomY, 0),
            Quaternion.identity
        );

        enemy.GetComponent<EnemyMovement>().direction = direction;
    }
}