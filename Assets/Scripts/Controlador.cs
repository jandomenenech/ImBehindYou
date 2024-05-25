using Photon.Pun;
using UnityEngine;

public class Controlador : MonoBehaviourPunCallbacks, IPunObservable
{
    public float moveSpeed = 0f;
    public float mouseSensitivity = 100f;

    private Rigidbody rb;

    [SerializeField] private GameObject camara;
    [SerializeField] private Bala bala;
    [SerializeField] private Rifle rifle;
    private float tiempo;
    [SerializeField] private GameObject armas;
    private Animator animator;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Canvas playerCanvas;

    [Header("Extra")]
    [SerializeField] private GameObject inventario;
    [SerializeField] private GameObject pausa;
    public bool canControl;

    Vector3 inicial;

    void Start()
    {
        tiempo = Time.time;
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        inicial = camara.transform.position;
        rb = GetComponent<Rigidbody>();
        canControl = true;

        if (photonView.IsMine)
        {
            playerCamera.gameObject.SetActive(true);
            playerCanvas.gameObject.SetActive(true);
        }
        else
        {
            playerCamera.gameObject.SetActive(false);
            playerCanvas.gameObject.SetActive(false);

        }
        if (rb == null)
        {
            Debug.LogError("Rigidbody no encontrado en el objeto del jugador.");
        }
        if (animator == null)
        {
            Debug.LogError("Animator no encontrado en el objeto del jugador.");
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {

            canControl = !inventario.activeInHierarchy && !pausa.activeInHierarchy;

            if (canControl)
            {

                float moveX = Input.GetAxis("Horizontal");
                float moveZ = Input.GetAxis("Vertical");
                Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
                rb.velocity = moveDirection * moveSpeed * Time.deltaTime;


                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    photonView.RPC("Disparar", RpcTarget.All);
                }

                rifle.recargar(animator);
                rifle.animarCuchillo(animator);


                gahterObject();
                Run(Walk());
                animator.SetFloat("walk", Mathf.Clamp01(moveSpeed));
            }
            else
            {

                rb.velocity = Vector3.zero;
            }
        }
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

    [PunRPC]
    public void Disparar()
    {
        rifle.disparar(animator);
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Enviar datos
            if (rb != null)
            {
                stream.SendNext(rb.position);
                stream.SendNext(rb.rotation);
            }
            else
            {
                stream.SendNext(Vector3.zero);
                stream.SendNext(Quaternion.identity);
            }
        }
        else
        {
            // Recibir datos
            if (rb != null)
            {
                rb.position = (Vector3)stream.ReceiveNext();
                rb.rotation = (Quaternion)stream.ReceiveNext();
            }
            else
            {
                stream.ReceiveNext(); // Saltar los datos si rb es null
                stream.ReceiveNext(); // Saltar los datos si rb es null
            }
        }
    }
}