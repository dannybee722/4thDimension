using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Go_To_GameOver : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
}
