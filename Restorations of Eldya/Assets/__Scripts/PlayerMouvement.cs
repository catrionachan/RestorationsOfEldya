using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));//takes positive value of speed and assigns it to "Speed" in animator


        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;//takes left and right input and multiplies by speed 
        if (Input.GetButtonDown("Jump")) //takes up down inputs and sets jump to true 
        {
            jump = true;
            animator.SetBool("IsJumping", true);//takes  value of jump and assigns it to "IsJumping" in animator

        }
        if (Input.GetButtonDown("Crouch")) //takes up down inputs and sets crouch to true 
        {
            crouch = true;

        }else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }

    }

    public void onLanding() 
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate() 
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);//move our character 
        jump = false;
    

    }


}
