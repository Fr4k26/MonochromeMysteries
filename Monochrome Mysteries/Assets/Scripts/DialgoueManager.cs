using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialgoueManager : MonoBehaviour
{
    GameController gc;
    public List<GameObject> buttonList;
    public GameObject buttonOption;
    public GameObject PaperBoyCanvas;
    public GameObject FemmeFataleCanvas;
    public Canvas choicePaperBoyMenu;
    public Canvas choiceFemmeFataleMenu;
    public Trigger paperBoyTrigger;
    public Trigger femmeFataleTrigger;
    
    

    public GameObject playerObject;
    public PlayerController playerController;

    public bool endDia;

    public Text nameText;
    public Text dialogueText;
    public Text femNameText;
    public Text femDialogueText;

    public Animator paperAnimator;
    public Animator femAnimator;
    public Animator paperTalking;
    public Animator femTalking;

    public Queue<string> sentences;

    public int buttonAmount;

    private bool stillTalking = false;
    public bool showChoices;

    public bool opensDoor; //Determines whether or not this dialogue opens a door
    public int doorTarget; //Determines which door will open

    //Audio Source Attached to Camera & Sound Effect Lists for Dialogue
    private AudioSource playerAudio;
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
        paperAnimator.SetBool("isOpen", true);
        femAnimator.SetBool("isOpen", true);

        if(paperBoyTrigger.boyTrigger == true)
        {
            paperTalking.SetBool("isTalking", true);
        }

        if(femmeFataleTrigger.femmeTrigger == true)
        {
            femTalking.SetBool("isTalking", true);
        }
        
       
        playerController.canmove = false;
        showChoices = false;
        nameText.text = dialogue.name;
        femNameText.text = dialogue.name;
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
        DisplayOptionsPaperBoy();
        DisplayOptionsFemmeFatale();

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

    public void DisplayOptionsPaperBoy()
    {
        playerController.canmove = false;
        if (showChoices == true)
       {
            choicePaperBoyMenu.gameObject.SetActive(true);
            playerController.canmove = false;
        }
        
       if(showChoices == false)
       {
            choicePaperBoyMenu.gameObject.SetActive(false);
       }
    }

    public void DisplayOptionsFemmeFatale()
    {
        playerController.canmove = false;

        if (showChoices == true)
        {
            choiceFemmeFataleMenu.gameObject.SetActive(true);
            playerController.canmove = false;
        }

        if (showChoices == false)
        {
            choiceFemmeFataleMenu.gameObject.SetActive(false);

        }

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        femDialogueText.text = "";

        if (femmeFataleTrigger.femmeTrigger == true)
        {
            playerAudio.PlayOneShot(femmeFatale[Random.Range(0, femmeFatale.Length)], 0.9F);
        }

        if (paperBoyTrigger.boyTrigger == true)
        {
            playerAudio.PlayOneShot(paperBoy[Random.Range(0, paperBoy.Length)], 0.9F);
        }
        
        if (stillTalking == true)
        {
            StartCoroutine(nextSound());
        }

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            femDialogueText.text += letter;
            yield return null;
            stillTalking = false;
        }
    }

    void EndDialogue()
    {
        playerController.canmove = true;

        paperAnimator.SetBool("isOpen", false);
        femAnimator.SetBool("isOpen", false);
        if(paperBoyTrigger.boyTrigger == false)
        {
            paperTalking.SetBool("isTalking", false);
            stillTalking = false;
        }

        if(femmeFataleTrigger.femmeTrigger == true)
        {
            femTalking.SetBool("isTalking", false);
            stillTalking = false;
        }


        if (paperBoyTrigger.boyTrigger == true)
        {
            showChoices = true;
            DisplayOptionsPaperBoy();
            playerController.canmove = false;
        }


        if (femmeFataleTrigger.femmeTrigger == true)
        {
            showChoices = true;
            DisplayOptionsFemmeFatale();
            playerController.canmove = false;
        }
        

        endDia = true;

        stillTalking = false;

        playerController.canmove = true;
    }

    //Calls for a new dialogue sound of the character in question is still talking based on the stillTalking boolean
    IEnumerator nextSound()
    {
        yield return new WaitForSeconds(0.706f);

        if (femmeFataleTrigger.femmeTrigger == true)
        {
            playerAudio.PlayOneShot(femmeFatale[Random.Range(0, femmeFatale.Length)], 0.8F);
        }

        if (paperBoyTrigger.boyTrigger == true)
        {
            playerAudio.PlayOneShot(paperBoy[Random.Range(0, paperBoy.Length)], 0.8F);
        }

        if (stillTalking == true)
        {
            StartCoroutine(nextSound());
        }
    }
}
