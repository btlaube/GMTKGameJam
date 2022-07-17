using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);
    }
}
