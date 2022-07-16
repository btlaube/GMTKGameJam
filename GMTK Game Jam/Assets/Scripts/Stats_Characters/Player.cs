using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float currentRolls;// {get; private set;}
    [SerializeField] public float currentHealth;// {get; private set;}

    [SerializeField] private float startingRolls;    
    [SerializeField] private float startingHealth;
    

    void Awake() {
        currentRolls = startingRolls;
        currentHealth = startingHealth;
    }

    void Update() {
        //if(Input.GetKeyDown(KeyCode.Space)) {
        //    Roll();
        //}
        //if(Input.GetKeyDown(KeyCode.S)) {
        //    TakeDamage(1f);
        //}
    }

    public void TakeDamage(float damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
    }

    public void Heal(float amount) {
        Debug.Log("heal " + amount);
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, startingHealth);
    }

    public void Roll() {
        currentRolls = Mathf.Clamp(currentRolls - 1, 0, 26);
    }

    public void AddRolls(float amount) {
        Debug.Log("add " + amount + " rolls");
        currentRolls = Mathf.Clamp(currentRolls + amount, 0, 26);
    }
}