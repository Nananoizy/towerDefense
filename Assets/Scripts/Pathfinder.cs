using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Waypoint searchCenter;
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] Waypoint startPoint, endPoint;

    bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        Pathfind();
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

    void ExploreNeighbours(){

        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions){

            Vector2Int explorationCoordinates = searchCenter.GetGridPos() + direction;
            //print(explorationCoordinates);
            try{

                Waypoint neigbour = grid[explorationCoordinates];
                
                if (neigbour.isExplored || queue.Contains(neigbour)){
                    
                }
                else{
                    neigbour.SetTopColor(Color.blue);
                    queue.Enqueue(neigbour);
                    neigbour.exploredFrom = searchCenter;
                }
                
            }
            catch{

            }

        }
    }

    void Pathfind(){

        queue.Enqueue(startPoint);

        while(queue.Count > 0 && isRunning){
            
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbours();
        }
    }

    private void HaltIfEndFound(){

        if (searchCenter == endPoint){
            isRunning = false;
        }
    }
}
