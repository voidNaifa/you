using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //[SerializeField]
    public Rigidbody2D player;

    //[SerializeField]
    public float movimentSpeed;
    public Animator anim;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
    

        Vector2 movement = new Vector2(horizontal,vertical);
        movement = movement.normalized;

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude); 
        
        this.player.velocity = movement * movimentSpeed;

    
    }

    /*void ManagerCollision(GameObject colision)
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
