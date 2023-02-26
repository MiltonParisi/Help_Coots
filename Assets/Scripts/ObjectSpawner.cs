using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform[] spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> spawnedObjects = new List<GameObject>();
        List<Transform> availableSpawnLocations = new List<Transform>(spawnLocations);

        // Loop through each spawn location
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            // Get a random object to spawn
            GameObject objectToSpawn = GetRandomObjectToSpawn(spawnedObjects, i);

            // Get a random available spawn location
            Transform spawnLocation = GetRandomAvailableSpawnLocation(availableSpawnLocations);

            // Spawn the object at the random location
            if (objectToSpawn != null)
            {
                Instantiate(objectToSpawn, spawnLocation.position, Quaternion.identity);

                // Add the spawned object to the list of spawned objects
                spawnedObjects.Add(objectToSpawn);

                // Remove the used spawn location from the list of available spawn locations
                availableSpawnLocations.Remove(spawnLocation);
            }
            else
            {
                Debug.LogWarning("No object to spawn.");
            }
        }
    }

    private GameObject GetRandomObjectToSpawn(List<GameObject> spawnedObjects, int index)
    {
        List<GameObject> availableObjectsToSpawn = new List<GameObject>();

        foreach (GameObject objectToSpawn in objectsToSpawn)
        {
            if (!spawnedObjects.Contains(objectToSpawn))
            {
                if (index == 1 || index == 2)
                {
                    // Exclude a specific object for elements 1 and 2
                    if (objectToSpawn.name != "Thumbnail")
                    {
                        availableObjectsToSpawn.Add(objectToSpawn);
                    }
                }
                else
                {
                    availableObjectsToSpawn.Add(objectToSpawn);
                }
            }
        }

        if (availableObjectsToSpawn.Count == 0)
        {
            Debug.LogWarning("All objects have been spawned.");
            return null;
        }

        return availableObjectsToSpawn[Random.Range(0, availableObjectsToSpawn.Count)];
    }

    private Transform GetRandomAvailableSpawnLocation(List<Transform> availableSpawnLocations)
    {
        if (availableSpawnLocations.Count == 0)
        {
            Debug.LogWarning("All spawn locations have been used.");
            return null;
        }

        return availableSpawnLocations[Random.Range(0, availableSpawnLocations.Count)];
    }
}
