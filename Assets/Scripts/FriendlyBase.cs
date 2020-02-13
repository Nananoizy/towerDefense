using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;


public class FriendlyBase : MonoBehaviour
{

    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthTxt;
    [SerializeField] AudioClip reachedBaseSFX;

    void Start(){

        healthTxt.text = health.ToString();

    }

    void OnTriggerEnter(Collider collider){

        health -= healthDecrease;
        GetComponent<AudioSource>().PlayOneShot(reachedBaseSFX);
        healthTxt.text = health.ToString();

    }
}
