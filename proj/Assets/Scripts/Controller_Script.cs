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

    [FMODUnity.EventRef]
    public string playerSteps = "event:/player_steps";
    FMOD.Studio.EventInstance stepsEv;
    FMOD.Studio.ParameterInstance stepsParam;
    /*
    [FMODUnity.EventRef]
    public string wormMove = "event:/player_worm_move";
    FMOD.Studio.EventInstance wormMoveEv;
    FMOD.Studio.ParameterInstance wormMoveParam;
    */

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();

        //Initialize FMOD events with parameters
        stepsEv = FMODUnity.RuntimeManager.CreateInstance(playerSteps);
        stepsEv.getParameter("moving", out stepsParam);
        stepsEv.start();
        stepsParam.setValue(0);
 
        /*
        wormMoveEv = FMODUnity.RuntimeManager.CreateInstance(wormMove);
        wormMoveEv.getParameter("moving", out wormMoveParam);
        wormMoveEv.start();
        wormMoveParam.setValue(0);
        */

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
        //use XXXXXparam.setValue to toggle between 'on' and 'off' states for move sounds
        /*if (Input.GetKeyDown("up"))
        {
            stepsParam.setValue(1f);
            Debug.Log("moving");
        }
        */
        //if jumping as young
        //when jump starts: FMODUnity.RuntimeManager.PlayOneShot(youngJump);
        //when contact made again: FMODUnity.RuntimeManager.PlayOneShot(youngLand);

        //if jumping as worm
        //on jump: FMODUnity.RuntimeManager.PlayOneShot(wormJump);

        //when smashing though wall
        //FMOD.Unity.RuntimeManager.PlayOneShot(smash);
	}
}
