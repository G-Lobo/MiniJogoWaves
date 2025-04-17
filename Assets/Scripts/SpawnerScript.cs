using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour


{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform _playerTransform;
    private float _spawnTimer;
    private float _spawnFrequency = 0.9f;
    
    void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (!(_spawnTimer >= _spawnFrequency) || !_playerTransform) return;
        var randomPos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            
        var randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            
        Instantiate(randomEnemy, randomPos, Quaternion.identity);
        _spawnTimer = 0;
    }
}