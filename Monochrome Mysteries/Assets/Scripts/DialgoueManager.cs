using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialgoueManager : MonoBehaviour
{
    
    //public List<GameObject> buttonList;
    public GameObject buttonOption;
    public GameObject canvasPrefab;

    public bool endDia;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    public int buttonAmount;


    //Audio Source Attached to Camera & Sound Effect Lists for Dialogue
    public AudioSource playerAudio;
    public AudioClip [] paperBoy;
    public AudioClip[] femmeFatale;
    public AudioClip[] policeMan;
    public AudioClip[] businessMan;
    public AudioClip[] mobster;

    void Start()
    {
        //buttonList = new List<GameObject>();
        endDia = true;
        sentences = new Queue<string>();

        //Establish Connection to Audio Source Attached to Camera to play Sound Effects
        playerAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();


    }

    public void DisplayNextSentence()
    {
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
        buttonOption.SetActive(true);
    }



    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        playerAudio.PlayOneShot(paperBoy[Random.Range(0, paperBoy.Length-1)], 0.7F);

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        
        if(endDia == true)
        {
            DisplayOptions();
        }
        endDia = false;
    }
}
