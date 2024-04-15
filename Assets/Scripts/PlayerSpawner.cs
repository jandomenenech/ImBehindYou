using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Array to hold your spawn points
    public GameObject player;

    void Start()
    {
        // Check if there are any spawn points
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned!");
            return;
        }

        // Get a random index to select a spawn point
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Teleport the player to the selected spawn point
        Transform spawnPoint = spawnPoints[randomIndex];
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
    }
}
