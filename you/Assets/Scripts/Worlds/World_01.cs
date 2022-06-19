using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_01 : MonoBehaviour
{   

    public GameObject bathroom_hall;
    public GameObject bathroom_wall;
    public GameObject bathroom;
    public GameObject bedroom;
    public GameObject kitchen;

    void Start()
    {
        transform.position = new Vector3 (-58,-95,0);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "cl_bedroom_door_out")
       {    
            bathroom.SetActive(true);
            bedroom.SetActive(false);
            transform.position = new Vector3 (53,135,0);
       } else if(collider.name =="cl_bedroom_door_in") 
       {
            bathroom.SetActive(false);
            bedroom.SetActive(true);
            transform.position = new Vector3 (58,3,0);
       }
        if(collider.name =="cl_bathroom_door_in")
       {
            bathroom_hall.SetActive(false);
            bathroom_wall.SetActive(true);
       } else if (collider.name =="cl_bathroom_door_out")
       {
            bathroom_hall.SetActive(true);
            bathroom_wall.SetActive(false);            
       }
        if(collider.name=="cl_kitchen_door_in")
        {
            bathroom.SetActive(false);
            kitchen.SetActive(true);
            transform.position = new Vector3 (53,504,0);
        } else if(collider.name == "cl_kitchen_door_out")
        {
            bathroom.SetActive(true);
            kitchen.SetActive(false);
            transform.position = new Vector3 (53,331,0);
        }
    }

}
