using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialgoueManager : MonoBehaviour
{
    public UnityEvent restartButton;
    GameController gc;
    public List<GameObject> buttonList;
    public GameObject buttonOption;
    public GameObject PaperBoyCanvas;
    public GameObject FemmeFataleCanvas;
    public GameObject MobBossCanvas;
    public GameObject BusinessManCanvas;
    public Canvas choicePaperBoyMenu;
    public Canvas choiceFemmeFataleMenu;
    public Canvas choiceMobBossMenu;
    public Canvas choiceBusinessManMenu;
    public Trigger paperBoyTrigger;
    public Trigger femmeFataleTrigger;
    public Trigger mobBossTrigger;
    public Trigger BusinessManTrigger;
    


    public GameObject playerObject;
    public PlayerController playerController;
    private Transform paperBoyFace, femmeFataleFace, mobBossFace, businessmanFace, playerFace; //Used to force the player to look at each character during dialouge


    public bool endDia;

    public Text nameText;
    public Text dialogueText;
    public Text femNameText;
    public Text femDialogueText;
    public Text mobNameText;
    public Text mobDialogueText;
    public Text manNameText;
    public Text manDialougeText;

    public float textSpeed = 0.016f;


    public Animator paperAnimator;
    public Animator femAnimator;
    public Animator mobAnimator;
    public Animator manAnimator;
    public Animator paperTalking;
    public Animator femTalking;
    public Animator mobTalking;
    public Animator manTalking;

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
    public AudioClip[] businessMan;
    public AudioClip[] mobBoss;

    void Start()
    {
        gc = FindObjectOfType<GameController>();
        buttonList = new List<GameObject>();
        endDia = true;
        sentences = new Queue<string>();
        playerController = playerObject.GetComponent<PlayerController>();
        playerFace = GameObject.Find("Main Camera").transform;
        paperBoyFace = GameObject.Find("Paperboy Face").transform;
        femmeFataleFace = GameObject.Find("Femme Fatale Face").transform;
        mobBossFace = GameObject.Find("Mob Boss Face").transform;
        businessmanFace = GameObject.Find("Businessman Face").transform;


        //Establish Connection to Audio Source Attached to Camera to play Sound Effects
        playerAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        paperAnimator.SetBool("isOpen", true);
        femAnimator.SetBool("isOpen", true);
        mobAnimator.SetBool("isOpen", true);
        manAnimator.SetBool("isOpen", true);

        if (paperBoyTrigger.boyTrigger == true)
        {
            paperTalking.SetBool("isTalking", true);
            playerFace.LookAt(paperBoyFace);
        }

        if(femmeFataleTrigger.femmeTrigger == true)
        {
            femTalking.SetBool("isTalking", true);
            playerFace.LookAt(femmeFataleFace);
        }

        if (mobBossTrigger.mobTrigger == true)
        {
            mobTalking.SetBool("isTalking", true);
            playerFace.LookAt(mobBossFace);
        }

        if(BusinessManTrigger.manTrigger == true)
        {
            manTalking.SetBool("isTalking", true);
            playerFace.LookAt(businessmanFace);
        }


        playerController.canmove = false;
        showChoices = false;
        nameText.text = dialogue.name;
        femNameText.text = dialogue.name;
        mobNameText.text = dialogue.name;
        manNameText.text = dialogue.name;

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
        DisplayOptionsMobBoss();
        DisplayOptionsBusinessman();
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

    public void DisplayOptionsMobBoss()
    {
        playerController.canmove = false;

        if (showChoices == true)
        {
            choiceMobBossMenu.gameObject.SetActive(true);
            playerController.canmove = false;
        }

        if (showChoices == false)
        {
            choiceMobBossMenu.gameObject.SetActive(false);

        }
    }

    public void DisplayOptionsBusinessman()
    {
        playerController.canmove = false;

        if (showChoices == true)
        {
            choiceBusinessManMenu.gameObject.SetActive(true);
            playerController.canmove = false;
        }

        if (showChoices == false)
        {
            choiceBusinessManMenu.gameObject.SetActive(false);
        }

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        femDialogueText.text = "";
        mobDialogueText.text = "";
        manDialougeText.text = "";
        

        if (femmeFataleTrigger.femmeTrigger == true)
        {
            playerAudio.PlayOneShot(femmeFatale[Random.Range(0, femmeFatale.Length)], 0.9F);
        }

        if (paperBoyTrigger.boyTrigger == true)
        {
            playerAudio.PlayOneShot(paperBoy[Random.Range(0, paperBoy.Length)], 0.9F);
        }

        if (mobBossTrigger.mobTrigger == true)
        {
            playerAudio.PlayOneShot(mobBoss[Random.Range(0, mobBoss.Length)], 0.9F);
        }
        if(BusinessManTrigger.manTrigger == true)
        {
            playerAudio.PlayOneShot(businessMan[Random.Range(0, mobBoss.Length)], 0.9F);

        }

        if (stillTalking == true)
        {
            StartCoroutine(nextSound());
        }

        //stillTalking = false;
        yield return null;
        
        if(PlayerPrefs.GetInt("displayAll", 0) == 1)
        {
            dialogueText.text = sentence;
            femDialogueText.text = sentence;
            mobDialogueText.text = sentence;
            manDialougeText.text = sentence;
            stillTalking = false;
        }
        else
        {
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                femDialogueText.text += letter;
                mobDialogueText.text += letter;
                manDialougeText.text += letter;
                yield return new WaitForSeconds(textSpeed);
                stillTalking = false;
            }
        }
    }

    void EndDialogue()
    {
        playerController.canmove = true;

        paperAnimator.SetBool("isOpen", false);
        femAnimator.SetBool("isOpen", false);
        mobAnimator.SetBool("isOpen", false);
        manAnimator.SetBool("isOpen", false);
        if(paperBoyTrigger.boyTrigger == false)
        {
            paperTalking.SetBool("isTalking", false);
            stillTalking = false;
        }

        if(femmeFataleTrigger.femmeTrigger == false)
        {
            femTalking.SetBool("isTalking", false);
            stillTalking = false;
        }

        if (mobBossTrigger.mobTrigger == false)
        {
            mobTalking.SetBool("isTalking", false);
            stillTalking = false;
        }
        if(BusinessManTrigger.manTrigger == false)
        {
            manTalking.SetBool("isTalking", false);
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

        if (mobBossTrigger.mobTrigger == true)
        {
            showChoices = true;
            DisplayOptionsMobBoss();
            playerController.canmove = false;
        }
        if (BusinessManTrigger.manTrigger == true)
        {
            showChoices = true;
            DisplayOptionsBusinessman();
            playerController.canmove = false;
        }


        endDia = true;

        stillTalking = false;

        playerController.canmove = true;
        if(currentTrigger != null)
        {
            currentTrigger.onConvoEnd.Invoke();
            currentTrigger = null;
        }
    }

    public static DialogueTrigger currentTrigger;

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

        if (mobBossTrigger.mobTrigger == true)
        {
            playerAudio.PlayOneShot(mobBoss[Random.Range(0, mobBoss.Length)], 0.8F);
        }
        if(BusinessManTrigger.manTrigger == true)
        {
            playerAudio.PlayOneShot(businessMan[Random.Range(0, businessMan.Length)], 0.8F);
        }

        if (stillTalking == true)
        {
            StartCoroutine(nextSound());
        }
    }
}
