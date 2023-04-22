using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int spawnEnemyStep;
    public float rateSpawn;
    public bool isSpawning;
    public GameObject enemy;
    public Transform[] enemySpawns;
    public Transform[] scaryMomentEnemySpawns;
    
    private Coroutine spawnEnemy;
    private int stability;

    public void ScaryMomentSpawnEnemy()
    {
        foreach (var pTransform in scaryMomentEnemySpawns)
        {
            Instantiate(enemy, pTransform.position, Quaternion.identity);
        }
    }

    public void UpdateStability(int _stability)
    {
        stability = _stability;
        
        if (stability <= spawnEnemyStep)
        {
            if (!isSpawning)
            {
                spawnEnemy = StartCoroutine(SpawningEnemy());
                isSpawning = true;
            }
        }
        else if(isSpawning)
        {
            StopCoroutine(spawnEnemy);
            isSpawning = false;
        }
    }

    public IEnumerator SpawningEnemy()
    {
        while (true)
        {
            int randIndex = Random.Range(0, enemySpawns.Length);

            Instantiate(enemy, enemySpawns[randIndex].position, Quaternion.identity);

            yield return new WaitForSeconds(rateSpawn);
        }
    }
}
