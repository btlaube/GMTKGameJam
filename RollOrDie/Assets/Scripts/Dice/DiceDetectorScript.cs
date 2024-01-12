using UnityEngine;

public class DiceDetectorScript : MonoBehaviour
{
    public Rigidbody dice;

    void OnTriggerStay() {
        if(dice.velocity == Vector3.zero) {
            if(transform.parent.parent.GetComponent<DiceScript>()) {
                transform.parent.parent.GetComponent<DiceScript>().SpawnDiceFace(int.Parse(transform.parent.name)-1);
            }
            else if(transform.parent.parent.GetComponent<OpponentDiceScript>()) {
                transform.parent.parent.GetComponent<OpponentDiceScript>().SpawnDiceFace(int.Parse(transform.parent.name)-1);
            }
        }
    }
}
