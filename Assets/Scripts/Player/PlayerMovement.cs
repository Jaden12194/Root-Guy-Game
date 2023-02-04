using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D Controller;

    public float runSpeed = 40f;
    private Rigidbody2D body;
    private Animator anim;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Awake()
    {
        //Grab ref for rig and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove =Input.GetAxisRaw("Horizontal")*runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch=false;
        }
        //set animatior paramiters
        //anim.SetBool("Run", horizontalMove != 0);
        //(It's supposed to call on "IsRunning", but it's also it's redundant for what we already got.)
    }

    private void FixedUpdate()
    {
        //moves character
        Controller.Move(horizontalMove*Time.fixedDeltaTime,crouch,jump);
        jump = false;
        
    }
}
