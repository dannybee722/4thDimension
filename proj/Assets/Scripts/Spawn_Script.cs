using UnityEngine;
using System.Collections;

public class Spawn_Script : MonoBehaviour {

    public GameObject object_to_create;
    public float spawn_time = 1f;

	// Use this for initialization
	void Start () {
        spawn_object();
	}
	
    void spawn_object()
    {
        Instantiate(object_to_create, transform.position, Quaternion.identity);
        Invoke("spawn_object", spawn_time);
    }
}
