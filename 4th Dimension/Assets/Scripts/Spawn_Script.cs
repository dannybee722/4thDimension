using UnityEngine;
using System.Collections;

public class Spawn_Script : MonoBehaviour {

    public GameObject object_to_create;
    public float spawn_time_min = 1f;
    public float spawn_time_max = 2f;

	// Use this for initialization
	void Start () {
        spawn_object();
	}
	
    void spawn_object()
    {
        Instantiate(object_to_create, transform.position, Quaternion.identity);
        Invoke("spawn_object", Random.Range(spawn_time_min, spawn_time_max));
    }
}
