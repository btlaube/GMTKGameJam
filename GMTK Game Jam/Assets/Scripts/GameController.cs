using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player player;
    public Transform gameCanvas; 
    public Transform playerDiceGrid; 
    public Opponent opponent;
    public Transform opponentDiceGrid;
    public CanvasGroupScript canvasGroup;

    private LevelLoader levelLoader;    

    void Start() {
        levelLoader = LevelLoader.instance;
    }

    void Update() {
        //Loses
        //Player dies
        if(player.currentHealth == 0) {
            Debug.Log("Lose");
            Lose();
        }
        //Player runs out of dice and rolls
        if(player.currentRolls == 0 && GameObject.Find("Dice(Clone)") == null && gameCanvas.Find("RolledDice(Clone)") == null && playerDiceGrid.childCount == 0) {
            Debug.Log("Lose");
            Lose();
        }

        //Wins
        //Opponent Dies
        if(opponent.currentHealth == 0) {
            Debug.Log("Win");
            Win();
        }
        //Opponent runs out of dice and rolls
        if(opponent.currentRolls == 0 && GameObject.Find("Opponent Dice(Clone)") == null && opponentDiceGrid.childCount == 0) {
            Debug.Log("Win");
            Win();
        }
    }

    public void Win() {
        Time.timeScale = 0f;
        canvasGroup.Win();
    }

    public void Lose() {
        Time.timeScale = 0f;
        canvasGroup.Lose();
    }

    public void Replay() {
        Time.timeScale = 1.0f;
        levelLoader.LoadGameScene();
    }

    public void Quit() {
        Time.timeScale = 1.0f;
        levelLoader.LoadMainMenu();
    }

}
