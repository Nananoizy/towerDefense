using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] float shootingDistance = 30f;
    ParticleSystem bullets;

    Transform targetEnemy;

    void Start(){
        
        bullets = transform.Find("Tower_A_Top").Find("Bullets").GetComponent<ParticleSystem>();

    }
    void Update()
    {
        SetTargetEnemy();

        if (targetEnemy){
            objectToPan.LookAt(targetEnemy);
            checkShooting();
        }
        else{
            Shoot(false);
        }
        
        
    }

    private void checkShooting(){

            float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, this.transform.position);

            if (distanceToEnemy <= shootingDistance){
                Shoot(true);
            }
            else{
                Shoot(false);
            }
        
    }

    private void Shoot(bool active){

        var emmissionModule = bullets.emission;
        emmissionModule.enabled = active;

    } 

    private void SetTargetEnemy(){

        var sceneEnemies = FindObjectsOfType<Enemy>(); //todos los gameobjects que tengan el script enemy

        if (sceneEnemies.Length == 0){ return; }
        
        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (Enemy testenemy in sceneEnemies){

            closestEnemy= GetClosest(closestEnemy, testenemy.transform);
        }

        targetEnemy = closestEnemy;

    }

    private Transform GetClosest(Transform transformA, Transform transformB){

        var thisToA = Vector3.Distance(transform.position, transformA.position);
        var thisToB = Vector3.Distance(transform.position, transformB.position);

        if (thisToA > thisToB){
            return transformB;
        }
        else{
            return transformA;
        }

    }
}
