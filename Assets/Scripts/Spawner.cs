using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Obstacles;
    public Transform[] spawnpoint;
    public int minWait;
    public int maxWait;
    int objToSpawn, actualSpawnPoint;

    private void Start()
    {
        StartCoroutine(Spawntimer());
    }

    public IEnumerator Spawntimer()
    {
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        objToSpawn = Random.Range(0, Obstacles.Length);
        actualSpawnPoint = Random.Range(0, spawnpoint.Length);
        Instantiate(Obstacles[objToSpawn], spawnpoint[actualSpawnPoint]);
        StartCoroutine(Spawntimer());
    }
}
