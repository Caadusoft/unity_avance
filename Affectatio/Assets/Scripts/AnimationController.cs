using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StateAnim
{
    Idle,
    Walk,
    Jump

}

public class AnimationController : MonoBehaviour {
    private Animator anim;
    private PlayerController player;
    private PlayerMotor playerMotor;
    private StateAnim state;
	
	void Start ()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        playerMotor = GetComponent<PlayerMotor>();
	}
	
	
	void Update ()
    {
        bool run = player.x == 1 || player.x == -1;
        if (run && playerMotor.Grounded)
        {
            state = StateAnim.Walk;
            Debug.Log("Je cours");
        }
        else if (!run && playerMotor.Grounded)
        {
            state = StateAnim.Idle;
            Debug.Log("Je ne fais rien");
        }
        else if (!playerMotor.Grounded)
        {
            state = StateAnim.Jump;
            Debug.Log("Je saute");
        }

        Animation();
    }

    private void Animation()
    {
        switch(state)
        {
            case StateAnim.Idle:
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
                anim.SetBool("Ground", true);
                break;
            case StateAnim.Walk:
                anim.SetBool("Run", true);
                anim.SetBool("Idle", false);
                anim.SetBool("Ground", true);
                break;
            case StateAnim.Jump:
                anim.SetBool("Ground", false);
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
                break;
                //Run, Idle et Ground sont définis dans les propriétés de la fenêtre Animation
        }
    }
}
