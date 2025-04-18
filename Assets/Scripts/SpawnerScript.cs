using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerScript : MonoBehaviour


{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform _playerTransform;
    [SerializeField] private GameObject _door;
    private float _spawnTimer;
    private float _spawnFrequency = 0.5f;
    private int _count = 0;

    void Update()
    {
        _spawnTimer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_spawnTimer >= _spawnFrequency)
        {
            while (_count < 10)
            {
                    var randomPos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

                    var randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

                    Instantiate(randomEnemy, randomPos, Quaternion.identity);
                    _spawnTimer = 0;
                    _count++;
                
            }

        }
    }
}