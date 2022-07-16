using UnityEngine;

public class OpponentRollScript : MonoBehaviour
{
    public GameObject dice;
    public Transform spawnPoint;
    public Player player;
    
    private Vector3 direction;
    private bool rolling = false;
    private static float time = 0.5f;

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
            direction = new Vector3(Random.Range(-1f, 1f), 0f, -1f) * 30f;

            GameObject newDice = Instantiate(dice, spawnPoint.position, Random.rotation);
            newDice.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);

            player.Roll();
        }        
    }
}
