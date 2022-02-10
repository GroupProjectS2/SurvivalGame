using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    //player's speed
    public float speed = 12f;

    //gravity variables
    public float gravity = -9.81f;
    public Vector3 velocity;

    public float jumpHeight = 3f;

    //ground check variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //gets player input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //calculates direction the player wants to move
        Vector3 move = transform.right * x + transform.forward * z;

        //moves player in direction intended
        controller.Move(move * speed * Time.deltaTime);

        //if no need for this delete all of this region
        #region Gravity and GroundCheck

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        #endregion
    }
}
