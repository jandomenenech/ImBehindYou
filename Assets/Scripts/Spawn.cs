using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject angledgrip;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Find the spawn point GameObject by name
        GameObject spawnPointObject = GameObject.Find("Objeto1SpawnTest");

        // Check if the spawn point GameObject was found
        if (spawnPointObject != null)
        {
            // Assign the transform of the found GameObject to spawnPoint
            spawnPoint = spawnPointObject.transform;

            // Spawn the object
            SpawnObject();
        }
        else
        {
            Debug.LogError("Spawn point not found! Make sure the spawn point GameObject is named Objeto1SpawnTest.");
        }
    }

    void SpawnObject()
    {
        Instantiate(angledgrip, spawnPoint.position, spawnPoint.rotation);
    }
}
