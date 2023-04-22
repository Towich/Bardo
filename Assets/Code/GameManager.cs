using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] enemySpawns;

    public void ScaryMomentSpawnEnemy()
    {
        foreach (var pTransform in enemySpawns)
        {
            Instantiate(enemy, pTransform.position, Quaternion.identity);
        }
    }
}
