using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    GameManager manager;



    float vInput;
    float hInput;
    public float speed = 10f;
    public float rotateSpeed = 50f;
    public float walkSpeed = 3f;
    public float runSpeed = 10f;
    //public float jumpHeight = 15f;
    public float gravity = -9.81f;

    public float velocity = 0f;
    public float transition = 4f;


    Vector3 movePlayer;
    Vector3 rotatePlayer;

    private void Start()
    {
        manager= FindObjectOfType<GameManager>();
        controller=GetComponent<CharacterController>();
    }
    private void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

       ;
        if (manager.isAlive)
        {
            if (vInput == 0)
            {
                Idle();
                if (velocity > 0f)
                {
                    velocity -= Time.deltaTime * transition;
                }
            }
            else if (vInput != 0 && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
                if (velocity <= 1f)
                {
                    velocity += Time.deltaTime * transition;

                }
                else if (velocity > 1f)
                {
                    velocity -= Time.deltaTime * transition;
                }
            }
            else if (vInput != 0 && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
                if (velocity <= 2f)
                {
                    velocity += Time.deltaTime * transition;
                }
            }


            rotatePlayer = Vector3.up * vInput * Time.deltaTime * rotateSpeed;
            transform.Rotate(rotatePlayer);

            movePlayer = Vector3.forward * vInput * Time.deltaTime;
            movePlayer = transform.TransformDirection(movePlayer);
            movePlayer.y += gravity;
            controller.Move(movePlayer * speed);
        }



           

        
        
        
    }





    private void Idle()
    {
        anim.SetFloat("Speed", velocity);
    }
    private void Walk()
    {
        speed= walkSpeed;
        anim.SetFloat("Speed", velocity);
    }
    private void Run()
    {
        speed= runSpeed;
        anim.SetFloat("Speed", velocity);
    }
}
