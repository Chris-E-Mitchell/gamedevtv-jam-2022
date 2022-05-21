using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject pickup;
    [SerializeField] int secondsBetweenSpawns = 2;
    [SerializeField] bool isSpawning = true;


    void Start()
    {
        StartCoroutine(SpawnPickups());
    }

    IEnumerator SpawnPickups()
    {
        while (isSpawning)
        {
            Instantiate(pickup, transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
