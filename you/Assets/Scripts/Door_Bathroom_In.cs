using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Bathroom_In : MonoBehaviour
{

public GameObject hall;
public GameObject wall;

void OnTriggerEnter2D(Collider2D collider)
{
    if(collider.CompareTag("Player"))
    {
        //door = true;
        hall.SetActive(false);
        wall.SetActive(true);
        Debug.Log("entrou");
    }        
}

}
