using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    [SerializeField] private bool esCaja;
    [SerializeField] private bool esConsumible;
    [SerializeField] private bool esAccesorio;
    private Animator animCaja;
    [SerializeField] private Transform personaje;
    [SerializeField] private Transform objeto;
    [SerializeField] private Inventario inventario;
    [SerializeField] public Texture textura;
    public GameObject cajainv;
    private int contador;
    private float time;

    void Start()
    {
        if (esCaja)
        {
            animCaja = GetComponent<Animator>();
        }
        contador = 0;
        time = Time.time;
    }

    void Update()
    {
        if (esCaja)
        {

            animacionCaja();
            

        }
        if (esAccesorio || esConsumible)
        {
            recogerObjeto();
        }
    }

    void animacionCaja()
    {
        float distancia = Vector3.Distance(personaje.position, objeto.position);
        int random = Random.Range(1, 5);

        if (Input.GetKeyDown(KeyCode.E))
        {
            cajainv.SetActive(true);

            if (distancia < 2f && contador != 1)
            {
                animCaja.SetInteger("Random", random);
                contador = 1;
                
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cajainv?.SetActive(false);
        }
    }

    void recogerObjeto()
    {
        float distancia = Vector3.Distance(personaje.position, objeto.position);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (distancia < 3f && contador != 1)
            {
                contador = 1;
                inventario.guardarEnInventario(gameObject,textura);
            }
        }
        
    }
}
