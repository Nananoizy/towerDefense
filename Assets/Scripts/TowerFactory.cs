using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject towerPrefab;
    [SerializeField] int limitTowers = 1;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTower(Waypoint baseWaypoint){

        Instantiate(towerPrefab, baseWaypoint.transform.position , Quaternion.identity);
        baseWaypoint.isPlaceable = false;
    }
}
