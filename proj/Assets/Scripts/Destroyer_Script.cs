using UnityEngine;
using System.Collections;

public class Destroyer_Script : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cloud1")
        {
            Vector3 pos = GameObject.FindGameObjectWithTag("Cloud1").transform.position;
            pos.x = GameObject.FindGameObjectWithTag("Cloud2").transform.position.x + 30.97f;
            GameObject.FindGameObjectWithTag("Cloud1").transform.position = pos;
            return;
        }
        else if (other.tag == "Cloud2")
        {
            Vector3 pos = GameObject.FindGameObjectWithTag("Cloud2").transform.position;
            pos.x = GameObject.FindGameObjectWithTag("Cloud1").transform.position.x + 30.97f;
            GameObject.FindGameObjectWithTag("Cloud2").transform.position = pos;
            return;
        }
        else if(other.tag == "BackDrop1")
        {
            Vector3 pos = GameObject.FindGameObjectWithTag("BackDrop1").transform.position;
            pos.x = GameObject.FindGameObjectWithTag("BackDrop2").transform.position.x;
            GameObject.FindGameObjectWithTag("BackDrop1").transform.position = pos;
            return;
        }
        else if (other.tag == "BackDrop2")
        {
            Vector3 pos = GameObject.FindGameObjectWithTag("BackDrop2").transform.position;
            pos.x = GameObject.FindGameObjectWithTag("BackDrop1").transform.position.x;
            GameObject.FindGameObjectWithTag("BackDrop2").transform.position = pos;
            return;
        }
        Destroy(other.gameObject);
    }
}
