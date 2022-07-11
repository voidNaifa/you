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
        inQuestion = question.GetComponent<Interaction>().inQuestion;
        if(playerInRange == true && Input.GetButtonDown("Fire1")) 
        {
            if(!dialogStarted)
            {
                StartDialogue();
            }
            else if(inQuestion)
            {
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
    }

    private void SkipDialogue()
    {
        if(dialogueText.text == dialogueLines[lineIndex])
        {
            NextDialogueLine();
        }
        else 
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];
        }        
    }
    private void StartDialogue()
    {   
        Time.timeScale = 0f;
        player.Game_False();
        dialogStarted = true;
        dialoguePanel.SetActive(true);
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

            dialogStarted = false;
            dialoguePanel.SetActive(false);
            player.Game_True();
            Time.timeScale = 1f;
        }
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char dg in dialogueLines[lineIndex])
        {
            dialogueText.text += dg;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
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
    
}
