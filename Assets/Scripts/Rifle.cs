using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rifle : MonoBehaviour
{
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

    void Start()
    {
        tiempo = Time.time;
    }

    void Update()
    {
        if (cuchillo)
        {
            animarCuchillo(animator);
        }
        if (rifle)
        {
            dispararRifle(animator);
            recargarRifle(animator);
            sumarBalasRifle();

        }
         if (pistola)
        {
            disparar(animator);
            recargar(animator);
            sumarBalasRifle();
        }

      
    }
    public void disparar(Animator anim)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && tiempo + 0.4f < Time.time && balas > 0)
        {
            anim.SetTrigger("Disparar");
            bala.Disparar();
            Debug.Log("Disparo");
            tiempo = Time.time;
            balas -= 1;
        }
    }
    public void recargar(Animator ani)
    {
        if (Input.GetKeyDown(KeyCode.R) && maxBalas>0 && tiempo + 0.8f< Time.time)
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
        }
        
    }
    public void dispararRifle(Animator anim)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && tiempo + 0.4f < Time.time && balasRifle > 0)
        {
            anim.SetTrigger("Disparar");
            bala.Disparar();
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

}
