﻿using UnityEngine;
using System.Collections;

public class Switch_Characters : MonoBehaviour {

    public GameObject Old_Character;
    public GameObject Teen_Character;
    public GameObject Baby_Character;

    public Camera moving_camera;
    private GameObject current_character;


    //Because the baby is shorter than the Old character,
    //keep a variable of the lowest position the old
    //character can have
    private float Old_initial_y;

    void Start()
    {
        current_character = Old_Character;
        Old_initial_y = Old_Character.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        //Switch to teen character
	    if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Make sure that current character isn't the one we're switching to
            switch_downward();
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch_upwards();
        }
	}

    //Switch "downwards in tree of characters.
    //If currently old char -> teen character
    //If currently teen -> baby
    //If currently baby -> old
    private void switch_downward()
    {
        if(current_character == Old_Character)
        {
            Controller_Script sc = current_character.GetComponent<Controller_Script>();
            switch_players(Teen_Character);
            sc.transition_character();

        }
        else if(current_character == Teen_Character)
        {
            switch_players(Baby_Character);
        }
        else
        {
            switch_players(Old_Character);
            
            //Test to see if the Current_character(old in this case)
            //is below it's lowest y, change it in that case
            if(current_character.transform.position.y < Old_initial_y)
            {
                //Transform the vector position
                Vector3 new_position = current_character.transform.position;
                new_position.y = Old_initial_y;
                current_character.transform.position = new_position;
            }

            Controller_Script sc = Old_Character.GetComponent<Controller_Script>();
            sc.transform_into();
        }
    }

    //Switch to a character upwards in the character tree
    //If currently baby -> teen
    //If currently teen -> old
    //else old -> baby
    private void switch_upwards()
    {
        if(current_character == Baby_Character)
        {
            switch_players(Teen_Character);
        }
        else if(current_character == Teen_Character)
        {
            switch_players(Old_Character);
        }
        else
        {
            switch_players(Baby_Character);
        }
    }
    

    //Switch between the current player and the chosen character
    private void switch_players(GameObject character_enable)
    {
        disable_character(current_character);
        enable_character(character_enable);

        Vector3 position = current_character.transform.position;
        position.x = moving_camera.transform.position.x;
        character_enable.transform.position = position;
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
