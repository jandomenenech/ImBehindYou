using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public bool arma;
    public bool cuchillo;
    public float balas;
    public float maxBalas;
    public Animator animator;
    private float tiempo;
    [SerializeField] private Bala bala;

    void Start()
    {
        tiempo = Time.time;
    }

    void Update()
    {
         if (arma)
        {
            disparar(animator);
            recargar(animator);
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
            Debug.Log(balas + "/" + maxBalas);
        }
    }
    public void recargar(Animator ani)
    {
        if (Input.GetKeyDown(KeyCode.R) && maxBalas>0)
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
        }
        
    }
}
