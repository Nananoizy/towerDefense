using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class cubeEditor : MonoBehaviour
{

    [Range(1f,20f)] [SerializeField] float gridSize = 10f;

    TextMesh textMesh;

    void Start(){
        
        textMesh = GetComponentInChildren<TextMesh>();
        
    }

    void Update()
    {

        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x/10f) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z/10f) * gridSize;

        string labelText = snapPos.x/gridSize + "," + snapPos.z/gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}
