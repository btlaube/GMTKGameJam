using UnityEngine;

public class DiceDetectorScript : MonoBehaviour
{
    public Rigidbody dice;

    [SerializeField] private bool landed;

    void OnTriggerStay() {
        if(dice.velocity == Vector3.zero) {
            if(!landed) {
                Debug.Log(transform.parent.name);
                //spawn correct dice
                landed = true;
            }
        }
    }
}
