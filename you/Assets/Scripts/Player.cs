using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D player;
    public float movimentSpeed;
    public Animator anim;
    bool gameOn = true;
    public GameObject fade;
    int idle;
    void Update()
    {        
        //gameIn = fade.GetComponent<Fade>().gameOn;
        //fade.GetComponent<Fade>().Teste();
        if(Time.timeScale == 1f && gameOn)
        {    
            float speed = anim.GetFloat("Speed");            
            if(speed == 0)
            {
                Idle();
            }
                            
            
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");        

            Vector2 movement = new Vector2(horizontal,vertical);
            movement = movement.normalized;
            
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", movement.magnitude); 
            this.player.velocity = movement * movimentSpeed;
            WalkAnimPlayer();

        }    
    }

    public void IdleUp()
    {
        idle = 1;
    }
    public void IdleDown()
    {
        idle = 2;
    }
    public void IdleLeft()
    {
        idle = 3;
    }
    public void IdleRight()
    {
        idle = 4;
    }          

    public void Idle()
    {
        if(idle == 1)
        {
            anim.Play("player_idle_up");
        }else if(idle == 2)
        {
            anim.Play("player_idle_down");
        }else if(idle == 3)
        {
           anim.Play("player_idle_left"); 
        }else if(idle == 4)
        {
           anim.Play("player_idle_right"); 
        }                        
    }  
    
    public void WalkAnimPlayer()
    {
        if(anim.GetFloat("Horizontal") > 0){
            anim.Play("player_walk_right");
        } else if(anim.GetFloat("Horizontal") < 0)
        {
            anim.Play("player_walk_left");
        }

        if(anim.GetFloat("Vertical") > 0 && anim.GetFloat("Horizontal") == 0)
        {
            anim.Play("player_walk_up");
        }else if(anim.GetFloat("Vertical") < 0 && anim.GetFloat("Horizontal") == 0)
        {
            anim.Play("player_walk_down");
        }
    }
    
    

    public void Game_True()
    {   
        gameOn = true;
    }
    public void Game_False()
    {   
        Idle();
        gameOn = false;

    }

    /*        if(collider.CompareTag("Door"))
        {
            if (door ==1)
            {
                transform.position = new Vector3 (59,135,0);
            }
        } 

    void ManagerCollision(GameObject colision)
    {
        if(colision.CompareTag("Door"))
        {
            Debug.Log("Passou a porta");
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        ManagerCollision(collider.gameObject);
    }
    */

}
