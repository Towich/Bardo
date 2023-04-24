using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject dialogueParent;
    public GameObject scaryMomentUI;
    
    public PlayerController player;
    
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

    public IEnumerator ShowScaryMomentUI()
    {
        dialogueParent.SetActive(true);
        Instantiate(scaryMomentUI, dialogueParent.transform);
        
        player.enabled = true;
        player.TurnMovement(true);
        
        player.TakeDecreaseStability(30, 0.2f, 0.5f);
        
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0;
        yield return null;
    }


    public void StartOpenDialogueAfterEnemies(GameObject nextDialoguePrefab, float deltaT)
    {
        StartCoroutine(OpenDialogueAfterEnemies(nextDialoguePrefab, 4f));
    }
    public IEnumerator OpenDialogueAfterEnemies(GameObject nextDialoguePrefab, float deltaT)
    {
        yield return new WaitForSeconds(deltaT);
        dialogueParent.SetActive(true);
        Instantiate(nextDialoguePrefab, dialogueParent.transform);
    }
}
