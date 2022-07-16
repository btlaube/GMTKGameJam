using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dice", menuName = "Dice")]
public class Dice : ScriptableObject
{
    public Sprite side;
    public float amount;
}
