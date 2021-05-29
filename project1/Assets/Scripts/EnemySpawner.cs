using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    
    Task spawn;

    private void Start()
    {
        spawn = new Task(SpawnAfterSeconds(4));
    }
    void Update()
    {
        if (!spawn.Running)
        {
            spawn = new Task(SpawnAfterSeconds(4));
        }
    }
    IEnumerator SpawnAfterSeconds(int t)
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 random = new Vector3(Random.Range(0f, 5f), Random.Range(0f, 5f), 0f);
            GameObject enemy = Instantiate(EnemyPrefab, this.transform.position + random, Quaternion.identity);
            enemy.SetActive(true);
        }
        yield return new WaitForSeconds(t);
    }
}
