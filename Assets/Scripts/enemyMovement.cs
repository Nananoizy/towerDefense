using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject enemyDeathFX;

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();

        var path = pathfinder.GetPath();

        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path){

        foreach (Waypoint waypoint in path){

            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(0.7f);

        }
        
        SelfDestruct();
    }

    void SelfDestruct(){

        Instantiate(enemyDeathFX, transform.position, Quaternion.identity);

        float destroyDelay = enemyDeathFX.GetComponent<ParticleSystem>().main.duration;

        Destroy(enemyDeathFX, destroyDelay);
        
        Destroy(gameObject);

    }


}
