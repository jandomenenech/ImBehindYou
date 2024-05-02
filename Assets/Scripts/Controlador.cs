using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public float moveSpeed = 0f;
    public float mouseSensitivity = 100f;

    private float verticalRotation = 0f;
    private Rigidbody rb;

    [SerializeField] private GameObject camara;
    [SerializeField] private Bala bala;
    [SerializeField] private Rifle rifle;
    private float tiempo;

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


        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        camara.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        gahterObject();
        Run(Walk());
       
        animator.SetFloat("walk", Mathf.Clamp01(moveSpeed));
        
        rifle.Disparar(tiempo, bala);
        rifle.recargar();
       
    }

    public void Run(bool caminando)
    {
        if (Input.GetKey(KeyCode.LeftShift) && caminando)
        {
            moveSpeed = 850f;
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
            moveSpeed = 600f;
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