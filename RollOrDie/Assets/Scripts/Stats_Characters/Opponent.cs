using UnityEngine;

public class Opponent : Player
{
    public Transform diceGrid;
    public Player player;

    private float waitTime = 2f;
    private float timer;
    private bool speedingUp;
    AudioManager audioManager;

    void Start() {
        audioManager = AudioManager.instance;
        timer = Time.timeSinceLevelLoad;
    }

    void Update () {
        if(Input.GetKeyDown(KeyCode.Space)) {
            speedingUp = true;
        }
        if(speedingUp) {
            if(Time.timeSinceLevelLoad >= timer + 1f) {
                Action();
                waitTime = Mathf.Clamp(waitTime - 0.05f, 0.5f, 2f);
                Debug.Log(waitTime);
                timer = Time.timeSinceLevelLoad;
            }
        }        
    }

    public void Action() {
        if(diceGrid.childCount > 0) {
            
            int action;
            //Special Cases
            if(currentRolls < 3) {
                action = 3;
            }
            else if(currentHealth < 10) {
                action = 2;
            }
            else {
                action = 1;
            }

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
