using UnityEngine;

public class DiceDetectorScript : MonoBehaviour
{
    public Rigidbody dice;
    //public GameObject rolledDice;
    //public Transform diceGrid;
    //public GameObject[] diceFaces;

    [SerializeField] private bool landed;

    //void Awake() {
    //    diceGrid = GameObject.Find("Dice Grid").transform;
    //}

    void OnTriggerStay() {
        if(dice.velocity == Vector3.zero) {
            if(!landed) {
                Debug.Log(transform.parent.name);
                //spawn correct dice
                //GameObject newDice = Instantiate(rolledDice, diceGrid.position, Quaternion.identity);
                //GameObject newDice = Instantiate(diceFaces[int.Parse(transform.parent.name)-1], diceGrid.position, Quaternion.identity);
                //newDice.transform.SetParent(diceGrid);
                landed = true;
                transform.parent.parent.GetComponent<DiceScript>().SpawnDiceFace(int.Parse(transform.parent.name)-1);
                //Destroy(gameObject);
            }
        }
    }
}
