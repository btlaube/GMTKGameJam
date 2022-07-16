using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image currentHealthBar;

    void Update() {
        currentHealthBar.fillAmount = player.currentHealth / 104;        
    }
}
