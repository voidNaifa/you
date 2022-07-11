using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Interaction : MonoBehaviour
{
    
    private bool playerInRange;
    [SerializeField] private GameObject questionPanel;
    [SerializeField] private TMP_Text questionText_1, questionText_2;
    [SerializeField] private GameObject buttom_1, buttom_2;   
    private string question;
    public bool inQuestion;
    bool repeat;
    [SerializeField] private Animator clock;



    void Update()
    {
        if(playerInRange == true && Input.GetButtonDown("Fire1")) 
        {   
            if(!inQuestion)
            {
                Question();
            }
            if(repeat)
            {
                Question();
            }
        }        
    }
    
   
    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        // World_01 //
        if(collider.name =="dg_bedroom_clock")
        {   
            Debug.Log("Estou");
            playerInRange = true;
            question = "Clock";

        }


    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        playerInRange = false;
        question = "";
    }

    void Question()
    {
     
        if(question == "Clock")
        {
            questionPanel.SetActive(true);
            inQuestion = true;   
            questionText_1.text = "Sim";
            questionText_2.text = "Não";
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(buttom_1);  
        }
    }

    public void Answer_1()
    {   
        inQuestion = false;
        if(question == "Clock")
        {   
            //question = "";
            Debug.Log("Feito");
            clock.Play("clock_off");
            questionPanel.SetActive(false);
            //inQuestion = false;
            repeat = true;
        }
    }
    public void Answer_2()
    {   
        //question = "";
        questionPanel.SetActive(false);
        //inQuestion = false;
        repeat = true;
    }
}
