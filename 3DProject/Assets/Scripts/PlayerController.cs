using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rBody;

    Animator animator;

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask; 

    Vector3 velocity;
    public float jumpHeight = 3f;
    bool isGrounded=true;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //if (isGrounded && velocity.y<0) 
        //{
        //    velocity.y = -2f;
        //}

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown("w"))
        {
            animator.SetInteger("Run", 1);
        }
        else if (Input.GetKeyDown("a"))
            {
            animator.SetInteger("Run", 1);
            }
        else if (Input.GetKeyDown("s"))
        {
            animator.SetInteger("Run", 1);
        }
        else if (Input.GetKeyDown("d"))
        {
            animator.SetInteger("Run", 1);
        }
        else
        {
            animator.SetTrigger("CombatIdle");
        }

        if (Input.GetKeyDown("Space") && isGrounded)
        {
            rBody.AddForce(new Vector3(0, 100, 0), ForceMode.Impulse);
            Debug.Log("jump");
            isGrounded = false;
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity* Time.deltaTime);
    }

    void onCollisionEnter(Collision other)
    {
        Debug.Log("collision");
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
