﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] float secondsBetweenSpawns = 1f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] AudioClip spawnedEnemySFX;

    private int spawnedEnemies = 0;

    [SerializeField] Text scoreText;
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){

        while (true){
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            spawnedEnemies ++;
            scoreText.text = spawnedEnemies.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        
    }
}
