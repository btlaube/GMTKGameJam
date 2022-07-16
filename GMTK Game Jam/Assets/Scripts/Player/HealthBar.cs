using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image currentHealthBar;

    void Update() {
        player = GameObject.Find("Player").GetComponent<Player>();        
        currentHealthBar.fillAmount = player.currentHealth / 104;        
    }
}
