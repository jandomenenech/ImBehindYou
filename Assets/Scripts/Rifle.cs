using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.Audio;

public class Rifle : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject camara;
    public bool pistola;
    public bool rifle;
    public bool cuchillo;
    public float balas;
    public float balasRifle;
    public float maxBalas;
    public float maxBalasRifle;
    public Animator animator;
    private float tiempo;
    public Inventario i;
    [SerializeField] private Bala bala;
    [SerializeField] private Controlador controlador;
    public AudioClip sonidoDisparo;
    private AudioSource audioSource;

    void Start()
    {
        tiempo = Time.time;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (controlador.canControl)
        {
            if (rifle)
            {
                if (photonView.IsMine)
                {
                    dispararRifle(animator);
                    recargarRifle(animator);
                    sumarBalasRifle();
                }
            }

            if (pistola && photonView.IsMine)
            {
                disparar(animator);
                recargar(animator);
                sumarBalasRifle();
            }
        }
    }

    public void disparar(Animator anim)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && tiempo + 0.4f < Time.time && balas > 0)
        {
            anim.SetTrigger("Disparar");
            Vector3 posicionDisparo = camara.transform.position + camara.transform.forward * 1.5f;
            Quaternion rotacionDisparo = camara.transform.rotation;
            photonView.RPC("DispararBala", RpcTarget.All, posicionDisparo, rotacionDisparo);
            tiempo = Time.time;
            balas -= 1;
            ReproducirSonidoDisparo(gameObject.transform.position);

        }
    }

    [PunRPC]
    public void DispararBala(Vector3 posicionDisparo, Quaternion rotacionDisparo)
    {
        // Código para crear y disparar la bala
        bala.Disparar(posicionDisparo, rotacionDisparo);


    }

    private void ReproducirSonidoDisparo(Vector3 posicion)
    {
        if (sonidoDisparo != null)
        {
            audioSource.transform.position = posicion;
            audioSource.clip = sonidoDisparo;
            audioSource.spatialBlend = 1.0f; // Esto asegura que el sonido sea 3D
            audioSource.Play();
        }
    }

    public void recargar(Animator ani)
    {
        if (Input.GetKeyDown(KeyCode.R) && maxBalas > 0 && tiempo + 0.8f < Time.time)
        {
            if (maxBalas + balas > 11)
            {
                ani.SetTrigger("Recargar");
                maxBalas -= (12 - balas);
                balas = 12;
            }
            else
            {
                ani.SetTrigger("Recargar");
                balas += maxBalas;
                maxBalas = 0;
            }
            tiempo = Time.time;
            ReproducirSonidoDisparo(gameObject.transform.position);
        }
    }

    public void dispararRifle(Animator anim)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && tiempo + 0.4f < Time.time && balasRifle > 0)
        {
            anim.SetTrigger("Disparar");
            Vector3 posicionDisparo = camara.transform.position + camara.transform.forward * 1.0f;
            Quaternion rotacionDisparo = camara.transform.rotation;
            photonView.RPC("DispararBala", RpcTarget.All, posicionDisparo, rotacionDisparo);
            Debug.Log("Disparo");
            tiempo = Time.time;
            balasRifle -= 1;
        }
    }

    public void recargarRifle(Animator ani)
    {
        if (Input.GetKeyDown(KeyCode.R) && maxBalasRifle > 0 && tiempo + 0.8f < Time.time)
        {
            if (maxBalasRifle + balasRifle > 11)
            {
                ani.SetTrigger("Recargar");
                maxBalasRifle -= (12 - balasRifle);
                balasRifle = 12;
            }
            else
            {
                ani.SetTrigger("Recargar");
                balasRifle += maxBalasRifle;
                maxBalasRifle = 0;
            }
            tiempo = Time.time;
        }
    }

    public void animarCuchillo(Animator animator)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Inspeccion");
        }
    }

    public void sumarBalasRifle()
    {
        if (i.tengoCargadorPistol())
        {
            maxBalas += 12;
        }
        if (i.tengoCargadorRifle())
        {
            maxBalasRifle += 24;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Enviar datos a otros jugadores
            stream.SendNext(balas);
            stream.SendNext(balasRifle);
            stream.SendNext(maxBalas);
            stream.SendNext(maxBalasRifle);
        }
        else
        {
            // Recibir datos de otros jugadores
            balas = (float)stream.ReceiveNext();
            balasRifle = (float)stream.ReceiveNext();
            maxBalas = (float)stream.ReceiveNext();
            maxBalasRifle = (float)stream.ReceiveNext();
        }
    }
}
