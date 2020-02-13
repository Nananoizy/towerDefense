using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBase : MonoBehaviour
{

    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;


    void OnTriggerEnter(Collider collider){

        health = health - healthDecrease;

    }
}
