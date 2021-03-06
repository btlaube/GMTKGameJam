using UnityEngine;

public class RollScript : MonoBehaviour
{
    public GameObject dice;
    public Transform spawnPoint;
    public Player player;
    
    private Vector3 direction;
    AudioManager audioManager;

    void Start() {
        audioManager = AudioManager.instance;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(player.currentRolls > 0) {
                Roll();
            }            
        }
    }

    public void Roll() {
        direction = new Vector3(Random.Range(-1f, 1f), 0f, 1f) * 50f;

        GameObject newDice = Instantiate(dice, spawnPoint.position, Random.rotation);
        newDice.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
        
        float randPitch = Random.Range(1f, 1.5f);
        audioManager.SetPitch("Dice Roll", randPitch);
        audioManager.Play("Dice Roll");

        player.Roll();
    }
}
