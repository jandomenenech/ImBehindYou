using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objeto : MonoBehaviour
{
    [SerializeField] private bool esCaja;
    [SerializeField] private bool esConsumible;
    [SerializeField] private bool esAccesorio;
    private Animator animCaja;
    [SerializeField] private Transform objeto;
    [SerializeField] public Texture textura;
    [SerializeField] public ItemsCaja itemsCaja;
    [SerializeField] private MostrarInvCaja inv;
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
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Inventario inventarioPlayer = player.GetComponent<Inventario>();
            float distancia = Vector3.Distance(player.transform.position, objeto.position);
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
                    inv.mostrarInventario(itemsCaja.objetoCaja);
                    inventarioPlayer.mostrarInventario();
                    Cursor.lockState = CursorLockMode.None;

                }
            }
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I))
            {
                inventarioPlayer.cerrarInventario();
                cajainv.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        
    }

    void recogerObjeto()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Inventario inventarioPlayer = player.GetComponent<Inventario>();
            float distancia = Vector3.Distance(player.transform.position, objeto.position);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (distancia < 3f && contador != 1)
                {
                    contador = 1;
                    inventarioPlayer.guardarEnInventario(gameObject, textura);
                }
            }
        }
        
    }
}
