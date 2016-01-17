using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Game_Over_To_Game : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
	}
}
