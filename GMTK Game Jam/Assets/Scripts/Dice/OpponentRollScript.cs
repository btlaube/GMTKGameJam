using UnityEngine;

public class OpponentRollScript : MonoBehaviour
{
    public GameObject dice;
    public Transform spawnPoint;
    public Player player;
    
    private Vector3 direction;
    private bool rolling = false;
    private static float time = 1f;
    AudioManager audioManager;

    void Start() {
        audioManager = AudioManager.instance;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(!rolling) {
                rolling = true;
                InvokeRepeating("Roll", time, time);
            }            
        }
    }

    public void Roll() {
        if(player.currentRolls > 0) {
            direction = new Vector3(Random.Range(-1f, 1f), 0f, -1f) * 50f;

            GameObject newDice = Instantiate(dice, spawnPoint.position, Random.rotation);
            newDice.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);

            audioManager.SetVolume("Dice Roll", 0.25f);
            float randPitch = Random.Range(1f, 1.5f);
            audioManager.SetPitch("Dice Roll", randPitch);
            audioManager.Play("Dice Roll");
            audioManager.SetVolume("Dice Roll", 0.5f);

            player.Roll();
        }        
    }
}
