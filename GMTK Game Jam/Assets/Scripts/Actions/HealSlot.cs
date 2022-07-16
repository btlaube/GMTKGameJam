using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HealSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Player player;

    public void OnDrop(PointerEventData eventData) {
        if(eventData.pointerDrag != null) {
            Destroy(eventData.pointerDrag);
            Action(eventData.pointerDrag.GetComponent<RolledDice>().dice.amount);
        }
    }

    public void Action(float amount) {
        Debug.Log("heal");
        player.Heal(amount);
    }
}
