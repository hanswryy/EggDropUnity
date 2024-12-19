using UnityEngine;
using System.Collections;

public class EggSpawner : MonoBehaviour
{
    public GameObject eggPrefab; // Reference to the egg prefab
    public Transform spawnPoint; // Reference to the spawn point

    void Start()
    {
        StartCoroutine(SpawnEggs());
    }

    IEnumerator SpawnEggs()
    {
        while (true)
        {
            // Wait for a random time between 5 to 10 seconds
            float waitTime = Random.Range(3f, 7f);
            // random x position
            float ranX = Random.Range(-265f, 265f);
            yield return new WaitForSeconds(waitTime);

            // rotation
            Quaternion rotation = Quaternion.Euler(-90, 0, 0);

            // Spawn the egg
            GameObject egg = Instantiate(eggPrefab, new Vector3(spawnPoint.position.x + ranX, spawnPoint.position.y, spawnPoint.position.z - 50), rotation);
        }
    }
}