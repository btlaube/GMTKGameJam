using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player player;
    public Transform gameCanvas; 
    public Transform playerDiceGrid; 
    public Opponent opponent;
    public Transform opponentDiceGrid;
    public CanvasGroupScript canvasGroup;

    private bool calledWin = false;
    private bool calledLose = false;
    private LevelLoader levelLoader;
    private AudioManager audioManager;

    void Start() {
        levelLoader = LevelLoader.instance;
        audioManager = AudioManager.instance;
    }

    void Update() {
        //Loses
        //Player dies
        if(player.currentHealth == 0) {
            if(!calledLose) {
                Lose();
            }
        }
        //Player runs out of dice and rolls
        if(player.currentRolls == 0 && GameObject.Find("Dice(Clone)") == null && gameCanvas.Find("RolledDice(Clone)") == null && playerDiceGrid.childCount == 0) {
            if(!calledLose) {
                Lose();
            }
        }

        //Wins
        //Opponent Dies
        if(opponent.currentHealth == 0) {
            if(!calledWin) {
                Win();
            }
        }
        //Opponent runs out of dice and rolls
        if(opponent.currentRolls == 0 && GameObject.Find("Opponent Dice(Clone)") == null && opponentDiceGrid.childCount == 0) {
            if(!calledWin) {
                Win();
            }            
        }

        if(Input.GetKeyDown(KeyCode.W)) {
            Win();
        }

        if(Input.GetKeyDown(KeyCode.L)) {
            Lose();
        }
    }

    public void Win() {
        calledWin = true;
        Time.timeScale = 0f;
        canvasGroup.Win();
        audioManager.Play("Victory");
    }

    public void Lose() {
        calledLose = true;
        Time.timeScale = 0f;
        canvasGroup.Lose();
        audioManager.Play("Lose");
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
