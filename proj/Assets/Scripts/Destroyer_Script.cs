using UnityEngine;
using System.Collections;

public class Destroyer_Script : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
