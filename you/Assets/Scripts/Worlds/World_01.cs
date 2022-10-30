using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using TMPro;
using UnityEngine.SceneManagement;

public class World_01 : MonoBehaviour
{   


    public GameObject bathroom_hall;
    public GameObject bathroom_local;
    public GameObject bathroom;
    public GameObject bedroom;
    public GameObject kitchen;

    [SerializeField] private GameObject player;
    public float count;
    public Animator fade;

    
    int door;
  
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.transform.position = new Vector3 (-150,-61,0);

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {   
        if(collider.name == "cl_bedroom_door_out")
       {    
            Fade();
            door = 1;            
       } else if(collider.name =="cl_bedroom_door_in") 
       {      
            Fade();
            door = 2;
       }
        if(collider.name =="cl_bathroom_door_in")
       {
            bathroom_hall.SetActive(false);
            bathroom_local.SetActive(true);
       } else if (collider.name =="cl_bathroom_door_out")
       {
            bathroom_hall.SetActive(true);
            bathroom_local.SetActive(false);            
       }
        if(collider.name=="cl_kitchen_door_in")
        {
            Fade();
            door = 3;
        } else if(collider.name == "cl_kitchen_door_out")
        {
            Fade();
            door = 4;
        }

        //////////////////////////////////Interação/////////////////////////////////




    }


    public void SceneFade()
    {
        if(door == 1)
        {
            bathroom.SetActive(true);
            bedroom.SetActive(false);
            player.transform.position = new Vector3 (-25,225,0);            
        }
        if(door == 2)
        {
            bathroom.SetActive(false);
            bedroom.SetActive(true);
            player.transform.position = new Vector3 (-32,37,0);
        }
        if(door == 3)
        {
            bathroom.SetActive(false);
            kitchen.SetActive(true);
            player.transform.position = new Vector3 (-38,543,0);            
        }
        if(door == 4)
        {
            bathroom.SetActive(true);
            kitchen.SetActive(false);
            player.transform.position = new Vector3 (-25,415,0);            
        }
    }


    public void Fade()
    {
        fade.Play("Fade");
    }



//////////////////////////  INTERAÇÕES  //////////////////////////////////////////////////////////////////////




}
