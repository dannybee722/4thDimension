using UnityEngine;
using System.Collections;

public class Create_Pillar_Script : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Vector3 pos = other.transform.position;
            pos.x = GameObject.FindGameObjectWithTag("Pos_Q").transform.position.x;
            other.transform.position = pos;
            return;
        }
    }
    }
