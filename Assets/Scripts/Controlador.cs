using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public float moveSpeed = 0f;
    public float mouseSensitivity = 100f;

    private CharacterController characterController;
    private float verticalRotation = 0f;

    [SerializeField] private GameObject camara;

    private Animator animator;
    Vector3 inicial;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        inicial = camara.transform.position;
    }

    void Update()
    {
       
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        gahterObject();
        Run(Walk());
        animator.SetFloat("walk", moveSpeed);
    }

    public void Run(bool caminando)
    {
        if (Input.GetKey(KeyCode.LeftShift) && caminando)
        {
            moveSpeed = 1f;
            camara.transform.position = new Vector3(camara.transform.position.x, 1.4f, camara.transform.position.z);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && caminando)
        {
            moveSpeed = 0.25f;
            camara.transform.position = new Vector3(camara.transform.position.x, 1.2f, camara.transform.position.z);
        }
        else if (caminando)
        {
            moveSpeed = 0.5f;
            camara.transform.position = new Vector3(camara.transform.position.x, 1.4f, camara.transform.position.z);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            moveSpeed = 0.1f;
            camara.transform.position = new Vector3(camara.transform.position.x, 0.8f, camara.transform.position.z);
        }
        else
        {
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