using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_01 : MonoBehaviour
{   

    public GameObject bathroom_hall;
    public GameObject bathroom_bath;
    public GameObject bathroom_wall;
    public GameObject BLACK_KITCHEN;
    public GameObject kitchen;

    void Start()
    {
        transform.position = new Vector3 (-58,-95,0);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "cl_bedroom_door_out")
       {
            transform.position = new Vector3 (53,135,0);
       } else if(collider.name =="cl_bedroom_door_in") 
       {
            transform.position = new Vector3 (58,3,0);
       }
        if(collider.name =="cl_bathroom_door_in")
       {
            bathroom_hall.SetActive(false);
            kitchen.SetActive(false);
            bathroom_wall.SetActive(true);
       } else if (collider.name =="cl_bathroom_door_out")
       {
            bathroom_hall.SetActive(true);
            kitchen.SetActive(true);
            bathroom_wall.SetActive(false);            
       }
        if(collider.name=="cl_kitchen_door_in")
        {
            bathroom_hall.SetActive(false);
            bathroom_bath.SetActive(false);
            BLACK_KITCHEN.SetActive(false);
        } else if(collider.name == "cl_kitchen_door_out")
        {
            bathroom_hall.SetActive(true);
            bathroom_bath.SetActive(true);   
            BLACK_KITCHEN.SetActive(true);         
        }
    }

}
