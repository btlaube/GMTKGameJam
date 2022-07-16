using UnityEngine;
using UnityEngine.UI;

public class DiceScript : MonoBehaviour
{
    public GameObject rolledDice;
    public Transform diceGrid;

    [SerializeField] private Dice[] diceFaces;

    void Awake() {
        diceGrid = GameObject.Find("Dice Grid").transform;
    }

    public void SpawnDiceFace(int face) {
        GameObject newDice = Instantiate(rolledDice, transform.position, Quaternion.identity);
        newDice.transform.SetParent(diceGrid);
        newDice.GetComponent<RolledDice>().dice = diceFaces[face];

        Destroy(gameObject);
    }
}