using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    const int gridSize = 10;

    public bool isExplored = false;

    Vector2Int gridPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetGridSize(){
        return gridSize;
    }

    public Vector2Int GetGridPos(){
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x/10f),
            Mathf.RoundToInt(transform.position.z/10f)
        );
    }

    public void SetTopColor(Color color){

        MeshRenderer topMeshR =  transform.Find("Top").GetComponent<MeshRenderer>();

        topMeshR.material.color = color;
    }
}
