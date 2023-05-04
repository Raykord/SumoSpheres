using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
	public GameObject powerUpPrefab;
	private float spawnRange = 9.0f;
    private int enemyCount;
    private int waveCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveCount);
		Instantiate(powerUpPrefab, GenerateSpawnPosition(), Quaternion.identity);
	}

	private void Update()
	{
		enemyCount = FindObjectsOfType<EnemyController>().Length;
		if (enemyCount == 0 )
        {
            waveCount++;
            SpawnEnemyWave(waveCount);
			Instantiate(powerUpPrefab, GenerateSpawnPosition(), Quaternion.identity);
		}    
	}
	private Vector3 GenerateSpawnPosition()
    {
		float spawnPosX = Random.Range(-spawnRange, spawnRange);
		float spawnPosZ = Random.Range(-spawnRange, spawnRange);
		Vector3 spawnPosition = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPosition;
	}

    private void SpawnEnemyWave(int enemysToSpawn)
    {
        for (int i = 0; i < enemysToSpawn; i++)
        {
			Instantiate(enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
		}
    }
}
