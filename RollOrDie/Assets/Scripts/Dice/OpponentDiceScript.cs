using UnityEngine;
using UnityEngine.UI;

public class OpponentDiceScript : MonoBehaviour
{
    public GameObject rolledDice;
    public Transform diceGrid;

    [SerializeField] private Dice[] diceFaces;
    private float rerollTime = 4f;
    private float rerollForce = 10f;

    void Awake() {
        diceGrid = GameObject.Find("Opponent Dice Grid").transform;
    }

    void Start() {
        InvokeRepeating("Reroll", rerollTime, rerollTime);
    }

    public void Reroll() {
        Vector3 direction = new Vector3(rerollForce, rerollForce, rerollForce);
        GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
    }

    public void SpawnDiceFace(int face) {
        GameObject newDice = Instantiate(rolledDice, transform.position, Quaternion.identity);
        newDice.transform.SetParent(diceGrid);
        newDice.GetComponent<RolledDice>().dice = diceFaces[face];

        Destroy(gameObject);
    }
}