using UnityEngine;
using System.Collections;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public int maxMonsterCount = 10;
    public float spawnInterval = 5f;

    private int currentMonsterCount = 0;

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (currentMonsterCount < maxMonsterCount)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
            Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
            currentMonsterCount++;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void MonsterKilled()
    {
        currentMonsterCount--;
    }
}