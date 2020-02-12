using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] Waypoint startPoint, endPoint;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbours();
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

    void ExploreNeighbours(){

        foreach(Vector2Int direction in directions){

            Vector2Int explorationCoordinates = startPoint.GetGridPos() + direction;
            //print(explorationCoordinates);
            grid[explorationCoordinates].SetTopColor(Color.blue);

        }
    }
}
