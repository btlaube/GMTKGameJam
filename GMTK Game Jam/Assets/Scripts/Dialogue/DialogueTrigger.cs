using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Dialogue dialogue;
    
    private DialogueManager dialogueManager;

    void OnEnable() {
        spriteRenderer.enabled = true;
    }

    void Start() {
        dialogueManager = DialogueManager.instance;
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.X)) {
            TriggerDialogue();
            spriteRenderer.enabled = false;
        }
    }

    public void TriggerDialogue() {
        dialogueManager.StartDialogue(dialogue);
    }
}