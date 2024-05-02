using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> spawnableObjects = new List<GameObject>(); // List to hold the GameObjects
    public float scaleFactor = 0.5f; // Scale factor to adjust the size of the spawned object
    private bool hasInitialized = false; // Flag to track if the initialization has been done

    void Start()
    {
        // Check if the initialization has already been done
        if (!hasInitialized)
        {
            // Add your three GameObjects to the list
            

            // Set the flag to true to indicate initialization is done
            hasInitialized = true;

            // Spawn a random object from the list
            SpawnRandomObject();
        }
    }

    void SpawnRandomObject()
    {
        // Check if there are objects in the list
        if (spawnableObjects.Count > 0)
        {
            // Get a random index within the range of the list
            int randomIndex = Random.Range(0, spawnableObjects.Count);

            // Instantiate the randomly selected object at the spawn point
            GameObject spawnedObject = Instantiate(spawnableObjects[randomIndex], transform.position, transform.rotation);

            // Adjust the scale of the spawned object
            spawnedObject.transform.localScale *= scaleFactor;
        }
        else
        {
            Debug.LogError("No spawnable objects assigned to the list!");
        }
    }
}



