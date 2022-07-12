using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Interaction : MonoBehaviour
{
    
    private bool playerInRange;
    [SerializeField] private GameObject questionPanel, dialoguePanel;
    [SerializeField] private GameObject clockObj;
    [SerializeField] private TMP_Text questionText_1, questionText_2;
    [SerializeField] private GameObject buttom_1, buttom_2;   
    private string question;
    public bool inQuestion;
    public bool questionStarted;

    private Player player;
    private Dialogue dialogue;
    //bool repeat;

    bool clockTurn = true;
    [SerializeField] private Animator clock;

    void Start()
    {   
        dialogue = FindObjectOfType<Dialogue>();
        player = FindObjectOfType<Player>();
    }

    /*void Update()
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
    */
    
   
    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        // World_01 //
        if(collider.name =="dg_bedroom_clock")
        {   
            question = "Clock";
            inQuestion = true;
            Debug.Log("Entrou numa pergunta");
        }
        else
        {
            question = "";
            inQuestion = false;            
        }


    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        question = "";
        inQuestion = false;
    }

    public void Question()
    {   
        if(question == "Clock")
        {
            questionStarted = true;         
        }
        else 
        {
            inQuestion = false;
            questionStarted = false;
        }
    }

    public void Questions()
    {
        if(question == "Clock")
        {   

            questionStarted = true;
            questionPanel.SetActive(true);
            questionText_1.text = "Sim";
            questionText_2.text = "Não";
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(buttom_1);  
            dialogue.onQuestion();    
        }     
    }

    public void Answer_1()
    {   
        if(question == "Clock")
        {      

            //question = "";
            Debug.Log("Feito");
            clock.Play("clock_off");
            questionPanel.SetActive(false);
            //dialoguePanel.SetActive(false);            
            //inQuestion = false;
            Invoke("EndQuestion", 0.1f);
            dialogue.NotDialogue();
            //Time.timeScale = 1f;
            //clockTurn = false;
            clockObj.SetActive(false);

        }
    }
    public void Answer_2()
    {   
        //question = "";
        questionPanel.SetActive(false);
        //dialoguePanel.SetActive(false);        
        //inQuestion = false;
        //Time.timeScale = 1f;
        dialogue.NotDialogue();
        Invoke("EndQuestion", 0.1f);
        //dialoguePanel.GetComponent<Dialogue>().NotDialogue(); 

    }

    private void EndQuestion()
    {
        questionStarted = false; 
    }
/*     void NotDialogue()
    {
        dialogue.NotDialogue();
        //dialogStarted = false;
        dialoguePanel.SetActive(false);
        player.Game_True();
        Time.timeScale = 1f;
    }
    */
} 
