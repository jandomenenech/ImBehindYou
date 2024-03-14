using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public float balas;
    public float maxBalas;
    public Animator animator;
    public void disparar(float tiempoDisparo, Bala bala)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && tiempoDisparo + 0.4f < Time.time && balas > 0)
        {
            animator.SetTrigger("Disparar");
            bala.Disparar();
            Debug.Log("Disparo");
            tiempoDisparo = Time.time;
            balas -= 1;
            Debug.Log(balas + "/" + maxBalas);
        }
    }
    public void recargar()
    {
        if (Input.GetKeyDown(KeyCode.R) && maxBalas>0)
        {
            if (maxBalas + balas > 11)
            {
                animator.SetTrigger("Recargar");
                maxBalas -= (12 - balas);
                balas = 12;
            }
            else
            {
                animator.SetTrigger("Recargar");
                balas += maxBalas;
                maxBalas = 0;
            }
        }
        
    }
}
