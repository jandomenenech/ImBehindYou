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
    [SerializeField] public ItemsCaja itemsCaja;
    public GameObject cajainv;
    private int contador;

    void Start()
    {
        if (esCaja)
        {
            animCaja = GetComponent<Animator>();
        }
        contador = 0;

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
            if (distancia < 2f)
            {
                if (contador != 1)
                {
                    animCaja.SetInteger("Random", random);
                    contador = 1;
                }
                itemsCaja.objetosCaja();
                cajainv.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cajainv?.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
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
