using UnityEngine;
using UnityEngine.UI;

public class OpponentDiceScript : MonoBehaviour
{
    public GameObject rolledDice;
    public Transform diceGrid;

    [SerializeField] private Dice[] diceFaces;

    void Awake() {
        diceGrid = GameObject.Find("Opponent Dice Grid").transform;
    }

    public void SpawnDiceFace(int face) {
        GameObject newDice = Instantiate(rolledDice, transform.position, Quaternion.identity);
        newDice.transform.SetParent(diceGrid);
        newDice.GetComponent<RolledDice>().dice = diceFaces[face];
        //newDice.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f, 0.4f);

        Destroy(gameObject);
    }
}