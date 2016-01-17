using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Start_Game : MonoBehaviour {
    
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            print("Space");
            SceneManager.LoadScene(1);
        }
	}
}
