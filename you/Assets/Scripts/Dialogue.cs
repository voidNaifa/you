using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Dialogue : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea (4, 6)] private string[] dialogueLines;
    [SerializeField] private GameObject question;
    private float typingSpeed = 0.05f;   
    private bool playerInRange; 
    private bool dialogStarted;
    private bool questionStarted;    
    private int lineIndex;
    private bool inQuestion;

    [Header("Other")]
    private Player player;



    void Start()
    {
        player = FindObjectOfType<Player>();
        playerInRange = false;
        dialogStarted = false;
    }
    void Update()
    {   
        Debug.Log("Está numa pergunta " + questionStarted);
        inQuestion = question.GetComponent<Interaction>().inQuestion;
        if(playerInRange == true && Input.GetButtonDown("Submit")) 
        {
            if(!dialogStarted && !questionStarted)
            {   
                Debug.Log("Comecou uma pergunta");
                StartDialogue();
            }
            else if (dialogStarted)
            {   
                Debug.Log("Tentou Skipar dialogo");
                SkipDialogue();
            }
        }
        if(playerInRange == true && Input.GetButtonDown("Cancel"))
        {
            if(dialogStarted)
            {
                SkipDialogue();
            }
        }
        onQuestion();
/*         if(dialogueText.text == dialogueLines[lineIndex] && inQuestion && !questionStarted)
        {
            question.GetComponent<Interaction>().Question();
        } */

    }

    private void SkipDialogue()
    {
        if(dialogueText.text == dialogueLines[lineIndex] && !inQuestion)
        {
            NextDialogueLine();
        }
        else if(dialogueText.text != dialogueLines[lineIndex] && !inQuestion)
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];                   
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex]; 
            question.GetComponent<Interaction>().Questions();

        }

/*         if(dialogueText.text != dialogueLines[lineIndex] && inQuestion && !questionStarted)
        {   
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];             
            question.GetComponent<Interaction>().Question();
        }
        else 
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];                
        } */
    }
    private void StartDialogue()
    {   
        Time.timeScale = 0f;
        player.Game_False();
        dialogStarted = true;
        dialoguePanel.SetActive(true);    
        question.GetComponent<Interaction>().Question();   
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            NotDialogue();
        }
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char dg in dialogueLines[lineIndex])
        {
            dialogueText.text += dg;
            if(dialogueText.text == dialogueLines[lineIndex] && inQuestion && questionStarted )
            {   
                Debug.Log("oq ta rolando");
                question.GetComponent<Interaction>().Questions();
            }
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    public void onQuestion()
    {
        questionStarted = question.GetComponent<Interaction>().questionStarted;
    }
    public void NotDialogue()
    {
        dialogStarted = false;
        dialoguePanel.SetActive(false);
        player.Game_True();
        Time.timeScale = 1f;
        questionStarted = question.GetComponent<Interaction>().questionStarted;        
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        // World_01 //
        if(collider.name =="Ray")
        {   
            playerInRange = true;
        }


    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        playerInRange = false;
    }
    
    public void DialogueFalse()
    {
        dialogStarted = false;
    }
}
