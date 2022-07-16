using UnityEngine;

public class RollScript : MonoBehaviour
{
    public GameObject dice;
    public Transform spawnPoint;
    public Player player;
    
    private Vector3 direction;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(player.currentRolls > 0) {
                Roll();
            }            
        }
    }

    public void Roll() {
        direction = new Vector3(Random.Range(-1f, 1f), 0f, 1f) * 30f;

        GameObject newDice = Instantiate(dice, spawnPoint.position, Random.rotation);
        newDice.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);

        player.Roll();
    }
}
