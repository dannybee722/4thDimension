using UnityEngine;
using System.Collections;

//Controller for the Old Character
public class Controller_Script : MonoBehaviour {

    public float max_speed = 10f;
    //public float jump_force = 700f;
    
    Animator animator;

    //creating FMOD events
    [FMODUnity.EventRef]
    public string smash = "event:/player_old_smash";

    /*
    [FMODUnity.EventRef]
    public string wormJump = "event:/player_worm_jump";

    [FMODUnity.EventRef]
    public string youngJump = "event:/player_jump_start";

    [FMODUnity.EventRef]
    public string youngLand = "event:/player_jump_end";
    */
    

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        
	}

    void Update()
    {
        //If action should be performed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Perform_Action");
        }

    }
	
	// Update is called once per frame
	private void FixedUpdate () {

       /* on_the_ground = Physics2D.OverlapCircle(ground_check.position, ground_radius, define_ground);
        animator.SetBool("Ground", on_the_ground);
        animator.SetFloat("y_speed", GetComponent<Rigidbody2D>().velocity.y);*/

        GetComponent<Rigidbody2D>().velocity = new Vector2(max_speed, GetComponent<Rigidbody2D>().velocity.y);
     
        //if jumping as young
        //when jump starts: FMODUnity.RuntimeManager.PlayOneShot(youngJump);
        //when contact made again: FMODUnity.RuntimeManager.PlayOneShot(youngLand);

        //if jumping as worm
        //on jump: FMODUnity.RuntimeManager.PlayOneShot(wormJump);

        //when smashing though wall
        //FMOD.Unity.RuntimeManager.PlayOneShot(smash);
	}

    public void transform_into()
    {
        animator.SetTrigger("Transform_Into");
    }

    public void transition_character()
    {
        animator.SetTrigger("Transform");
    }

}
