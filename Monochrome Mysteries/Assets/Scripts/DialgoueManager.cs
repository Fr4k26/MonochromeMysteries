using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialgoueManager : MonoBehaviour
{
    GameController gc;
    public List<GameObject> buttonList;
    public GameObject buttonOption;
    public GameObject canvasPrefab;
    public Canvas choiceMenu;
    

    public GameObject playerObject;
    public PlayerController playerController;

    public bool endDia;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public Queue<string> sentences;

    public int buttonAmount;

    private bool stillTalking = false;
    public bool showChoices;

    public bool opensDoor; //Determines whether or not this dialogue opens a door
    public int doorTarget; //Determines which door will open

    //Audio Source Attached to Camera & Sound Effect Lists for Dialogue
    public AudioSource playerAudio;
    public AudioClip[] paperBoy;
    public AudioClip[] femmeFatale;
    public AudioClip[] policeMan;
    public AudioClip[] businessMan;
    public AudioClip[] mobster;

    void Start()
    {
        gc = FindObjectOfType<GameController>();
        buttonList = new List<GameObject>();
        endDia = true;
        sentences = new Queue<string>();
        playerController = playerObject.GetComponent<PlayerController>();
        

        //Establish Connection to Audio Source Attached to Camera to play Sound Effects
        playerAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        //playerController.canmove = false;
        showChoices = false;
        nameText.text = dialogue.name;
        if(opensDoor)
        {
            gc.doors[doorTarget].SetActive(false);
        }

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        DisplayOptions();

    }

    public void DisplayNextSentence()
    {
        stillTalking = true;
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayOptions()
    {
       if(showChoices == true)
       {
            choiceMenu.gameObject.SetActive(true);
            
       }
        
       if(showChoices == false)
       {
            choiceMenu.gameObject.SetActive(false);
       }
        
        
    }



    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        playerAudio.PlayOneShot(paperBoy[Random.Range(0, paperBoy.Length-1)], 0.9F);
        if (stillTalking == true)
        {
            StartCoroutine(nextSound());
        }

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
            stillTalking = false;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);

        showChoices = true;
        DisplayOptions();
            
      
        endDia = true;
        stillTalking = false;
       
        //playerController.canmove = true;
    }

    IEnumerator nextSound()
    {
        yield return new WaitForSeconds(0.706f);
        playerAudio.PlayOneShot(paperBoy[Random.Range(0, paperBoy.Length - 1)], 0.8F);
        if (stillTalking == true)
        {
            StartCoroutine(nextSound());
        }
    }
}
