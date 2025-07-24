using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public DoorController doorController; // kéo vào trong Inspector

    private bool hasSpawned = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasSpawned && other.CompareTag("Player"))
        {
            SpawnEnemies();
            hasSpawned = true;
        }
    }

    void SpawnEnemies()
    {
        GameObject[] enemies = new GameObject[spawnPoints.Length];

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            enemies[i] = Instantiate(enemyPrefab, spawnPoints[i].position, Quaternion.identity);
        }

        doorController.SetEnemies(enemies);
    }
}
