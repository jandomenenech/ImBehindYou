using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class Controlador : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 0f;
    public float mouseSensitivity = 100f;

    private float verticalRotation = 0f;
    private Rigidbody rb;

    [SerializeField] private GameObject camara;
    [SerializeField] private Bala bala;
    [SerializeField] private Rifle rifle;
    private float tiempo;
    [SerializeField] private GameObject armas;
    private Animator animator;

    
    Vector3 inicial;
    void Start()
    {
        tiempo = Time.time;
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        inicial = camara.transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        rb.velocity = moveDirection * moveSpeed * Time.deltaTime;

       

        gahterObject();
        Run(Walk());

        animator.SetFloat("walk", Mathf.Clamp01(moveSpeed));
        rifle.disparar(animator);
        rifle.recargar(animator);
        rifle.animarCuchillo(animator);

    }



    public void Run(bool caminando)
    {
        if (Input.GetKey(KeyCode.LeftShift) && caminando)
        {
            moveSpeed = 1250f;
            camara.transform.position = new Vector3(camara.transform.position.x, camara.transform.position.y, camara.transform.position.z);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            moveSpeed = 0.1f;
            camara.transform.position = new Vector3(camara.transform.position.x, camara.transform.position.y, camara.transform.position.z);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && caminando)
        {
            moveSpeed = 2f;
            camara.transform.position = new Vector3(camara.transform.position.x, camara.transform.position.y, camara.transform.position.z);
        }
        else if (caminando)
        {
            moveSpeed = 1000f;
            camara.transform.position = new Vector3(camara.transform.position.x, camara.transform.position.y, camara.transform.position.z);
        }
      
        else
        {
            camara.transform.position = new Vector3(camara.transform.position.x, camara.transform.position.y, camara.transform.position.z);
            moveSpeed = 0;
            
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