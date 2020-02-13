using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] int hits = 20;

    [SerializeField] AudioClip damagedEnemySFX;

    void Start()
    {
    }

    void OnParticleCollision(GameObject other){
        
        hits--;

        GetComponent<AudioSource>().PlayOneShot(damagedEnemySFX);

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
