using UnityEngine;
using UnityEngine.UI;

public class RollsBar : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image currentRollsBar;

    void Update() {
        currentRollsBar.fillAmount = player.currentRolls / 26;        
    }
}
