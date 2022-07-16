using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIElementDragger : EventTrigger {

    private bool dragging;
    private CanvasGroup canvasGroup;
    private Transform diceGrid;

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        diceGrid = transform.parent;
    }

    void Update() {
        if (dragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        transform.SetParent(transform.parent.parent);
        dragging = true;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public override void OnPointerUp(PointerEventData eventData) {
        transform.SetParent(diceGrid);
        dragging = false;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }
}