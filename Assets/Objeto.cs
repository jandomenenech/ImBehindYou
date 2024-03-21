using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    [SerializeField] private bool esCaja;
    [SerializeField] private bool esConsumible;
    [SerializeField] private bool esAccesorio;
    [SerializeField] private Animator animCaja;
    [SerializeField] private Transform personaje;
    [SerializeField] private Transform objeto;
    public int contador;


    void Start()
    {
        contador = 0;
    }

    void Update()
    {
        if (esCaja)
        {
            animacionCaja();
        }
    }

    void animacionCaja()
    {
        float distancia = Vector3.Distance(personaje.position, objeto.position);
        int random = Random.Range(1, 3);
      
        if (distancia < 1f && contador!=1)
        {
            animCaja.SetInteger("Random",random);
            contador = 1;
        }
    }
}
