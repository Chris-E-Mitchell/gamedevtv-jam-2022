using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> pickups;
    [SerializeField] float minSecondsBetweenSpawns = 1f;
    [SerializeField] float maxSecondsBetweenSpawns = 4f;
    [SerializeField] bool isSpawning = true;


    void Start()
    {
        StartCoroutine(SpawnPickups());
    }

    IEnumerator SpawnPickups()
    {
        while (isSpawning)
        {
            float waitSeconds = Random.Range(minSecondsBetweenSpawns, maxSecondsBetweenSpawns);
            yield return new WaitForSeconds(waitSeconds);

            int randomIndex = Random.Range(0, pickups.Count);
            GameObject pickup = pickups[randomIndex];
            Instantiate(pickup, transform.position, Quaternion.identity, transform);
        }
    }
}
