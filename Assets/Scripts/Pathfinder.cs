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

    private List<Waypoint> path = new List<Waypoint>();

    bool isRunning = true;

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
                
            if(grid.ContainsKey(explorationCoordinates)){

                Waypoint neigbour = grid[explorationCoordinates];
                
                if (neigbour.isExplored || queue.Contains(neigbour)){
                    
                }
                else{
                    queue.Enqueue(neigbour);
                    neigbour.exploredFrom = searchCenter;
                }
                
            }

        }
    }

    void BreadthFirstSearch(){

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

    private void FormPath(){

        path.Add(endPoint);
        endPoint.isPlaceable = false;

        Waypoint previous = endPoint.exploredFrom;

        while(previous != startPoint){

            path.Add(previous);

            previous = previous.exploredFrom;
            previous.isPlaceable = false;

        }

        path.Add(startPoint);
        startPoint.isPlaceable = false;
        path.Reverse();
    }

    public List<Waypoint> GetPath(){

        if (path.Count == 0){

            LoadBlocks();
            BreadthFirstSearch();
            ColorStartAndEnd();
            FormPath();
        }

        return path;
        
    }
}
