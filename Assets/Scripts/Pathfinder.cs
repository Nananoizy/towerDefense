using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startPoint, endPoint;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
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

    void ColorStartAndEnd(){

        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);

    }
}
