using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player player;
    public Transform gameCanvas; 
    public Transform playerDiceGrid; 
    public Opponent opponent;
    public Transform opponentDiceGrid;

    CanvasGroupScript canvasGroup;

    void Start() {
        canvasGroup = CanvasGroupScript.instance;
    }

    void Update() {
        //Loses
        //Player dies
        if(player.currentHealth == 0) {
            Debug.Log("Lose");
        }
        //Player runs out of dice and rolls
        if(player.currentRolls == 0 && GameObject.Find("Dice(Clone)") == null && gameCanvas.Find("RolledDice(Clone)") == null && playerDiceGrid.childCount == 0) {
            Debug.Log("Lose");
        }

        //Wins
        //Opponent Dies
        if(opponent.currentHealth == 0) {
            Debug.Log("Win");
        }
        //Opponent runs out of dice and rolls
        if(opponent.currentRolls == 0 && GameObject.Find("Opponent Dice(Clone)") == null && opponentDiceGrid.childCount == 0) {
            Debug.Log("Win");
        }
    }

    public void Win() {
        canvasGroup.Win();
    }

    public void Lose() {
        canvasGroup.Lose();
    }

    public void Replay() {
        
    }

    public void Quit() {

    }

}
