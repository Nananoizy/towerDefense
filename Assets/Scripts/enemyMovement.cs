using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<Waypoint> path;
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath(){

        foreach (Waypoint waypoint in path){

            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
