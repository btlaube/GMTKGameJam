using UnityEngine;
using UnityEngine.UI;

public class RolledDice : MonoBehaviour
{
    public Dice dice;

    void Start() {
        GetComponent<Image>().sprite = dice.side;
    }
}
