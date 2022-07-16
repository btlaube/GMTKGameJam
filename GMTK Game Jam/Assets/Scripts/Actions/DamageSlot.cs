using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DamageSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Player player;

    public void OnDrop(PointerEventData eventData) {
        if(eventData.pointerDrag != null) {
            Action(eventData.pointerDrag.GetComponent<RolledDice>().dice.amount);
            Destroy(eventData.pointerDrag);
        }
    }

    public void Action(float amount) {
        Debug.Log("damage");
        player.TakeDamage(amount);
    }
}
