using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using WebSocketSharp;
using System;
using JetBrains.Annotations;

public class Inventario : MonoBehaviour
{
    [SerializeField] public List<RawImage> nombreInventario;
    [SerializeField] public List<GameObject> inventario;
    private Transform personaje;
    [SerializeField] public GameObject panelInventario;
    [SerializeField] 
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
                   
                }
            }
            contador = 0;
        }
        
    }

    public bool tengoCargadorRifle()
    {
        foreach (RawImage t in nombreInventario)
        {
            if (t.texture != null && t.texture.name == "cargadorR")
            {
                t.texture = null;
                t.color = new Color(255, 255, 255, 0f);
                return true;
            }
        }
        return false;
    }

    public bool tengoCargadorPistol()
    {
        foreach (RawImage t in nombreInventario)
        {
            if (t.texture != null && t.texture.name == "cargadorP")
            {
                t.texture = null;
                t.color = new Color(255, 255, 255, 0f);
                return true;
            }
        }
        return false;
    }


    public void activarInventario()
    {
        if (Input.GetKeyDown(KeyCode.I) && inventarioActivo == false)
        {
            Cursor.lockState = CursorLockMode.None;
            mostrarInventario();
        }
        else if((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape)) && inventarioActivo == true)
        {
            cerrarInventario();
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
    public void mostrarInventario()
    {
        inventarioActivo = true;
        panelInventario.SetActive(inventarioActivo);
    }

    public void cerrarInventario()
    {
        inventarioActivo = false;
        panelInventario.SetActive(false);
    }
}
