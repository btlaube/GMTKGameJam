using UnityEngine;

public class Opponent : Player
{
    public Transform diceGrid;
    public Player player;

    private static float time = 1.6f;
    AudioManager audioManager;

    void Start() {
        InvokeRepeating("Action", time, time);
        audioManager = AudioManager.instance;
    }

    public void Action() {
        if(diceGrid.childCount > 0) {
            
            int action = Random.Range(1, 4);
            switch (action) {
                case 1:
                    audioManager.SetVolume("Damage", 0.25f);
                    audioManager.SetPitch("Damage", 1+(diceGrid.GetChild(0).GetComponent<RolledDice>().dice.amount/10f));
                    audioManager.Play("Damage");
                    audioManager.SetVolume("Damage", 0.5f);

                    player.TakeDamage(diceGrid.GetChild(0).GetComponent<RolledDice>().dice.amount);
                    break;
                case 2:
                    audioManager.SetVolume("Heal", 0.25f);
                    audioManager.SetPitch("Heal", 1+(diceGrid.GetChild(0).GetComponent<RolledDice>().dice.amount/10f));
                    audioManager.Play("Heal");
                    audioManager.SetVolume("Heal", 0.5f);

                    Heal(diceGrid.GetChild(0).GetComponent<RolledDice>().dice.amount);
                    break;
                case 3:
                    audioManager.SetVolume("Buy Rolls", 0.25f);
                    audioManager.SetPitch("Buy Rolls", 1+(diceGrid.GetChild(0).GetComponent<RolledDice>().dice.amount/10f));
                    audioManager.Play("Buy Rolls");
                    audioManager.SetVolume("Buy Rolls", 0.5f);

                    AddRolls(diceGrid.GetChild(0).GetComponent<RolledDice>().dice.amount);
                    break;
            }
            Destroy(diceGrid.GetChild(0).gameObject);
        }
    }
}
