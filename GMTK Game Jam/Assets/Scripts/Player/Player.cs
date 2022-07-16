using UnityEngine;

public class Player : MonoBehaviour
{
    public float currentRolls {get; private set;}
    public float currentHealth {get; private set;}

    [SerializeField] private float startingRolls;    
    [SerializeField] private float startingHealth;
    

    void Awake() {
        currentRolls = startingRolls;
        currentHealth = startingHealth;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Roll();
        }
        if(Input.GetKeyDown(KeyCode.S)) {
            TakeDamage(1f);
        }
    }

    public void TakeDamage(float damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
    }

    public void Roll() {
        currentRolls = Mathf.Clamp(currentRolls - 1, 0, startingRolls);
    }
}
