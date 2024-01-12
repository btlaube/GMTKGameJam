using UnityEngine;

public class CanvasGroupScript : MonoBehaviour
{
    public static CanvasGroupScript instance;

    private AudioManager audioManager;

    void Start() {
        audioManager = AudioManager.instance;
    }

    public void Win() {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void Lose() {
        transform.GetChild(2).gameObject.SetActive(true);
    }
}
