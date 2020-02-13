using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float shootingDistance = 30f;

    ParticleSystem bullets;

    // Update is called once per frame

    void Start(){
        
        bullets = transform.Find("Tower_A_Top").Find("Bullets").GetComponent<ParticleSystem>();

    }
    void Update()
    {
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

            print("Mi distancia con la torre es: " + distanceToEnemy);
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
}
