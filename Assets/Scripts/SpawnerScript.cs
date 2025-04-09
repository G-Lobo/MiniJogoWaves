using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private float _spawnTimer;
    Transform spawner;
    
    void Update()
    {
       
        
        
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= 0.5f)
        {
            Vector3 randomPos = new Vector3(Random.Range(-10,10), 6, 0);
            
            Instantiate(enemyPrefab, randomPos, Quaternion.identity);
            _spawnTimer = 0;
        }
    }
}