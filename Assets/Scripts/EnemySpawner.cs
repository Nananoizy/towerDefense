using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] float secondsBetweenSpawns = 1f;
    [SerializeField] GameObject enemyPrefab;
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){

        while (true){
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        
    }
}
