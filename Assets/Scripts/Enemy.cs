using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] int hits = 20;

    void Start()
    {
    }

    void OnParticleCollision(GameObject other){
        
        hits--;

        if (hits <= 0){
            KillEnemy();
        }
    }

    void KillEnemy(){

        Instantiate(enemyDeathFX, transform.position, Quaternion.identity);

        float destroyDelay = enemyDeathFX.GetComponent<ParticleSystem>().main.duration;

        Destroy(enemyDeathFX, destroyDelay);

        Destroy(gameObject);

    }

}
