using UnityEngine;
using System.Collections.Generic;
using System.Collections;   

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public  float speed = 10;
    public  float gravity = -9.81f * 2;
    public  float JumpHeight = 3f;
    public Transform groundCheck;
    public float grouondDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    bool isMooving;
    private Vector3 lastPositin = new Vector3(0f, 0f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, grouondDistance, groundMask);
        // resetando velocidade
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //Vetores de direção
        Vector3 move = transform.right * x + transform.forward * y;

        //Movendo o player
        controller.Move(move * speed * Time.deltaTime);
         if (Input.GetButtonDown("Jump") && isGrounded)
        {   
            // pulo
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        // coindo
        velocity.y += gravity * Time.deltaTime;

        // pulando
        controller.Move(velocity * Time.deltaTime);

        //Check se está se movendo
        if (lastPositin != gameObject.transform.position && isGrounded == true)
        {
            isMooving = true;
            
        }
        else
        {
            isMooving = false;

        }
        lastPositin = gameObject.transform.position;


    }
}
