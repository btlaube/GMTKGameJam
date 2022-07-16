using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RollsSlot : EventTrigger
{
    public Player player;

    public override void OnDrop(PointerEventData eventData) {
        if(eventData.pointerDrag != null) {
            Destroy(eventData.pointerDrag);
            Action();
        }
    }

    public void Action() {
        Debug.Log("rolls");
        //player.AddRolls();
    }
}
