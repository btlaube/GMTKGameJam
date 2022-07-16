using UnityEngine;

public class Opponent : Player
{
    public Transform diceGrid;
    public Player player;

    private static float time = 1.6f; 

    void Start() {
        InvokeRepeating("Action", time, time);
    }

    public void Action() {
        if(diceGrid.childCount > 0) {
            
            int action = Random.Range(1, 4);
            switch (action) {
                case 1:
                    Debug.Log("AI did damage: " + diceGrid.GetChild(0).GetComponent<RolledDice>().dice.amount);
                    player.TakeDamage(diceGrid.GetChild(0).GetComponent<RolledDice>().dice.amount);
                    break;
                case 2:
                    Debug.Log("AI healed " + diceGrid.GetChild(0).GetComponent<RolledDice>().dice.amount);
                    Heal(diceGrid.GetChild(0).GetComponent<RolledDice>().dice.amount);
                    break;
                case 3:
                    Debug.Log("AI added rolls: " + diceGrid.GetChild(0).GetComponent<RolledDice>().dice.amount);
                    AddRolls(diceGrid.GetChild(0).GetComponent<RolledDice>().dice.amount);
                    break;
            }
            Destroy(diceGrid.GetChild(0).gameObject);
        }
    }
}
