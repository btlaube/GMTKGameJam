using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator dialogueAnimator;
    
    //[SerializeField] private NewPlayerMovement playerMovement;
    private Queue<string> sentences;
    
    private AudioManager audioManager;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
    
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        sentences = new Queue<string>();
        audioManager = AudioManager.instance;
    }

    void Update() {
        //if(SceneManager.GetActiveScene().buildIndex == 3) {
        //    playerMovement = GameObject.Find("Player").GetComponent<NewPlayerMovement>();
        //}        
        if(Input.GetKeyUp(KeyCode.Return)) {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue) {
        dialogueAnimator.SetTrigger("Open");
        //playerMovement.enabled = false;

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        else {
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence (string sentence) {
        audioManager.Play("Typing");
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
        audioManager.Stop("Typing");
    }

    void EndDialogue() {
        dialogueAnimator.SetTrigger("Close");
        //playerMovement.enabled = true;
    }
}