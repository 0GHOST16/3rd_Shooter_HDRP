using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 3f;
    public int enemyCount = 0;
    public int maxEnemyCount = 0;
    public bool isspawned = false;

    void Update()
    {
        if(enemyCount < maxEnemyCount)
        {
            if (!isspawned)
            {
                StartCoroutine(SpawnEnemy());
                isspawned = true;
                enemyCount++;
            }
        }
    }


    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnInterval);
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        isspawned = false;
    }
}
