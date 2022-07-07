using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public Animator fade;
    public Rigidbody2D world;
    //public bool gameOn = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trade()
    {
        world.GetComponent<World_01>().SceneFade();
    }
    public void FadeAll()
    {
        Time.timeScale = 0f;
        world.GetComponent<Player>().Game_False();
    } 

    public void Fade_0()
    {
        fade.Play("Fade_0");     
        Time.timeScale = 1f;  
        //Invoke("True", 0.001f);      
    }
    void True()
    {
        world.GetComponent<Player>().Game_True();           
    }
}
