using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject towerPrefab;
    [SerializeField] int limitTowers = 5;
    Queue<GameObject> towerQueue = new Queue<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTower(Waypoint baseWaypoint){

        int numTowers = towerQueue.Count;

        if (limitTowers > numTowers){
            
            InstantiateNewTower(baseWaypoint);

        }
        else{
            
            MoveTower(baseWaypoint);
        }
        
    }

    private void InstantiateNewTower(Waypoint baseWaypoint){

        var tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        tower.GetComponent<Tower>().baseWaypoint = baseWaypoint;

        towerQueue.Enqueue(tower);
        baseWaypoint.isPlaceable = false;

    }

    private void MoveTower(Waypoint baseWaypoint){

        var oldTower = towerQueue.Dequeue();
        oldTower.GetComponent<Tower>().baseWaypoint.isPlaceable = true;
        baseWaypoint.isPlaceable = false;

        oldTower.transform.position = baseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);

    }
}
