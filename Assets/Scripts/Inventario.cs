using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using WebSocketSharp;
using System;

public class Inventario : MonoBehaviour
{
    [SerializeField] public List<RawImage> nombreInventario;
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
        objetosVacios();
    }

    public void guardarEnInventario(GameObject objeto, Texture textura)
    {
        if (objeto.tag.Equals("Medkit") || objeto.tag.Equals("Bottle"))
        {
            inventario.Add(objeto);
            objeto.SetActive(false);
            objeto.transform.position = personaje.position;
        }
        else
        {
            foreach (RawImage t in nombreInventario)
            {
                if (t.texture == null && contador != 1)
                {
                    t.texture = textura;
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
        
    }

    public void activarInventario()
    {
        if (Input.GetKeyDown(KeyCode.I) && inventarioActivo == false)
        {
            Cursor.lockState = CursorLockMode.None;  
            inventarioActivo = true;
            panelInventario.SetActive(inventarioActivo);
        }
        else if((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape)) && inventarioActivo == true)
        {
            inventarioActivo=false;
            panelInventario.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    
    void objetosVacios()
    {
        foreach (RawImage t in nombreInventario)
        {
            if (t.texture == null)
            {
                t.color = new Color(255,255,255,0f);
            }
            else
            {
                t.color = new Color(255,255,255,1f);
            }
    }
}
}
