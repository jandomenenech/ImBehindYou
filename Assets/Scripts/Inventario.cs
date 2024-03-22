using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    [SerializeField] public List<GameObject> inventario;
    private int maxInventario;
    private Transform personaje;
    void Start()
    {
        maxInventario = 16;
        personaje = GetComponent<Transform>();
    }

    void Update()
    {
       
    }

    public void guardarEnInventario(GameObject objeto)
    {
        if (inventario.Count <= maxInventario)
        {
            inventario.Add(objeto);
            objeto.SetActive(false);
            objeto.transform.position = personaje.position;
        }
        else
        {

        }
    }
}
