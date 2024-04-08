using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    [SerializeField] public List<GameObject> inventario;
    private int maxInventario;
    private Transform personaje;
    [SerializeField] private GameObject panelInventario;
    private bool inventarioActivo;
    void Start()
    {
        maxInventario = 14;
        personaje = GetComponent<Transform>();
        inventarioActivo = false;
    }

    void Update()
    {
        activarInventario();
    }

    public void guardarEnInventario(GameObject objeto)
    {
        if (inventario.Count < maxInventario)
        {
            inventario.Add(objeto);
            objeto.SetActive(false);
            objeto.transform.position = personaje.position;
        }
        else
        {

        }
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
