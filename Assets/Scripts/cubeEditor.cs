using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class cubeEditor : MonoBehaviour
{

    Waypoint waypoint;

    void Start(){
        
        waypoint = GetComponent<Waypoint>();
        
    }

    void Update()
    {

        snapCube();
        updateLabel();
        
    }

    void updateLabel(){

        int gridSize = waypoint.GetGridSize();

        TextMesh textMesh = GetComponentInChildren<TextMesh>();

        Vector2 snapPos = waypoint.GetGridPos();
        string labelText = snapPos.x + "," + snapPos.y;
        textMesh.text = labelText;
        gameObject.name = labelText;

    }

    void snapCube(){

        int gridSize = waypoint.GetGridSize();
        
        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize, 
            0f, 
            waypoint.GetGridPos().y * gridSize
        );
    }
}
