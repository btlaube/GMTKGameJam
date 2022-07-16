using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DamageSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Player player;
    AudioManager audioManager;

    void Start() {
        audioManager = AudioManager.instance;
    }

    public void OnDrop(PointerEventData eventData) {
        if(eventData.pointerDrag != null) {
            Action(eventData.pointerDrag.GetComponent<RolledDice>().dice.amount);
            Destroy(eventData.pointerDrag);
        }
    }

    public void Action(float amount) {
        audioManager.SetPitch("Damage", 1+(amount/10f));
        audioManager.Play("Damage");

        player.TakeDamage(amount);
    }
}
