using UnityEngine;
using System.Collections;

public class Switch_Characters : MonoBehaviour {

    public GameObject Old_Character;
    public GameObject Teen_Character;
    private GameObject current_character;

    void Start()
    {
        current_character = Old_Character;
    }
	
	// Update is called once per frame
	void Update () {
        //Switch to teen character
	    if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Make sure that current character isn't the one we're switching to
            if (current_character == Teen_Character) return;
            switch_players(Teen_Character);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (current_character == Old_Character) return;
            switch_players(Old_Character);
        }
	}

    private void switch_players(GameObject character_enable)
    {
        disable_character(current_character);
        enable_character(character_enable);

        character_enable.transform.position = current_character.transform.position;
        current_character = character_enable;
    }

    private void disable_character(GameObject character)
    {
        foreach (Behaviour childcomp in character.GetComponentsInChildren<Behaviour>())
        {
            childcomp.enabled = false;
        }
        character.SetActive(false);
    }

    private void enable_character(GameObject character)
    {
        foreach (Behaviour childcomp in character.GetComponentsInChildren<Behaviour>())
        {
            childcomp.enabled = true;
        }
        character.SetActive(true);
    }
}
