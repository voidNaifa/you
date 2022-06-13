using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Bathroom_Out : MonoBehaviour
{

public GameObject hall;
public GameObject wall;

void OnTriggerEnter2D(Collider2D collider)
{
    if(collider.CompareTag("Player"))
    {
        //door = fal;
        hall.SetActive(true);
        wall.SetActive(false);
        Debug.Log("saiu");
    }
}

}
