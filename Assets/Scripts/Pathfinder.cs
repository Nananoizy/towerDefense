using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadBlocks(){

        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints){

            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());

            if (!isOverlapping){
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
            else{
                Debug.LogWarning("Overlapping block: " + waypoint.GetGridPos());
            }
            
        }

    }
}
