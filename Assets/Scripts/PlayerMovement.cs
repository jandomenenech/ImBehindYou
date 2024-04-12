using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad; 
    private Rigidbody rb;
    private Animator animator;
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        bool caminando = Walk();
        Run(caminando);
        gahterObject();

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);
        rb.velocity = movimiento * velocidad;

        if (movimiento != Vector3.zero)
        {
            Quaternion nuevaRotacion = Quaternion.LookRotation(movimiento);
            
            transform.rotation = Quaternion.Euler(0, nuevaRotacion.eulerAngles.y, 0);
        }

        animator.SetFloat("walk", velocidad);

    }





    //Funciones

    public void Run(bool caminando)
    {
        if (Input.GetKey(KeyCode.LeftShift) && caminando)
        {
            velocidad = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftControl) && caminando)
        {
            velocidad = 0.25f;
        }
        else if (caminando)
        {
            velocidad = 0.5f;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            velocidad = 0.1f;
        }
        else
        {
            velocidad = 0;
        }
    }

    public bool Walk()
    {
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
    }

    public void gahterObject()
    {
        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("PressE", true);
        }
        else
        {
            animator.SetBool("PressE", false);
        }
         
    }
}


/* public CharacterController controller;

 public float speed = 10f;
 public float gravity = -9.18f;
 public float jumpHeight = 3f;

 public Transform groundCheck;
 public float groundDistance = 0.4f;
 public LayerMask groundMask;

 bool isGrounded;
 Vector3 velocity;

 // Update is called once per frame
 void Update()
 {

     isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

     if (isGrounded && velocity.y < 0)
     {
         velocity.y = -2f;
     }

     float x = Input.GetAxis("Horizontal");
     float z = Input.GetAxis("Vertical");

     Vector3 move = transform.right * x + transform.forward * z;

     controller.Move(move * speed * Time.deltaTime);

     velocity.y += gravity * Time.deltaTime;
     controller.Move(velocity * Time.deltaTime);


     if (Input.GetKeyDown(KeyCode.LeftShift))
     {
         speed = 20f;

     }

     if (Input.GetKeyDown(KeyCode.LeftControl))
     {
         speed = 5f;
     }

     if (Input.GetButtonDown("Jump") && isGrounded)
     {
         velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
     }
 }*/


