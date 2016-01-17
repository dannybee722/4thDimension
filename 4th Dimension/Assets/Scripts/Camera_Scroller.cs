using UnityEngine;
using System.Collections;

public class Camera_Scroller : MonoBehaviour {

    public float roll_speed = 1f;
    private Vector3 new_position_camera;

	// Use this for initialization
	void Start () {
        new_position_camera = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        new_position_camera.x += Time.deltaTime * roll_speed;
        transform.position = new_position_camera;
	
	}
}
