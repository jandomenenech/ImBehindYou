using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    [SerializeField] public List<TextMeshProUGUI> nombreInventario;
    [SerializeField] public List<GameObject> inventario;
    private Transform personaje;
    [SerializeField] private GameObject panelInventario;
    private bool inventarioActivo;
    int contador;
    void Start()
    {
        personaje = GetComponent<Transform>();
        inventarioActivo = false;
        contador = 0;
    }

    void Update()
    {
        activarInventario();
    }

    public void guardarEnInventario(GameObject objeto)
    {
        
        foreach (TextMeshProUGUI t in nombreInventario)
        {
            string texto = t.text.ToString().Trim();
            if (texto.Equals("-") && contador!=1)
            {
                string[] hola = objeto.name.ToString().Split("(");
                t.text = hola[0];
                inventario.Add(objeto);
                objeto.SetActive(false);
                objeto.transform.position = personaje.position;
                contador = 1;
            }
            else
            {
                Debug.Log("No va");
            }
        }
        contador = 0;
        
    }

    void activarInventario()
    {
        if (Input.GetKeyDown(KeyCode.I) && inventarioActivo == false)
        {
            inventarioActivo = true;
            panelInventario.SetActive(inventarioActivo);
        }
        else if((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape)) && inventarioActivo == true)
        {
            inventarioActivo=false;
            panelInventario.SetActive(false); 
        }
    }
}
