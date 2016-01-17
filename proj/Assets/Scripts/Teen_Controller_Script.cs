using UnityEngine;
using System.Collections;

//Controller for the Teen character
public class Teen_Controller_Script : MonoBehaviour
{

    public float max_speed = 10f;
    public float jump_force = 700f;

    public Transform ground_check;
    public LayerMask define_ground;
    float ground_radius = 0.2f;
    bool on_the_ground = false;

    Animator animator;

    //Create FMOD events
    [FMODUnity.EventRef]
    public string youngJump = "event:/player_jump_start";

    [FMODUnity.EventRef]
    public string youngLand = "event:/player_jump_end";

    [FMODUnity.EventRef]
    public string playerSteps = "event:/player_steps";
    FMOD.Studio.EventInstance stepsEv;
    FMOD.Studio.ParameterInstance stepsParam;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

        //Initialize FMOD events with parameters
        stepsEv = FMODUnity.RuntimeManager.CreateInstance(playerSteps);
        stepsEv.getParameter("moving", out stepsParam);
        stepsEv.start();
        stepsParam.setValue(0);
    }

    void Update()
    {
        //If action should be performed
        if (on_the_ground && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump_force));
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        on_the_ground = Physics2D.OverlapCircle(ground_check.position, ground_radius, define_ground);
        animator.SetBool("Ground", on_the_ground);
        animator.SetFloat("y_speed", GetComponent<Rigidbody2D>().velocity.y);

        GetComponent<Rigidbody2D>().velocity = new Vector2(max_speed, GetComponent<Rigidbody2D>().velocity.y);


    }


}
