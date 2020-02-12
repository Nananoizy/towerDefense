using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] int hits = 3;



    void Start()
    {
    }

    void OnParticleCollision(GameObject other){
        
        hits--;

        if (hits <= 0){
            KillEnemy();
            Destroy(other);
        }
    }

    void KillEnemy(){

        Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

}
