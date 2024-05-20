using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargador : MonoBehaviour
{
    [SerializeField] private Rifle rifle;
    [SerializeField] private bool cargadorRifle;
    [SerializeField] private bool cargadorPistol;
    [SerializeField] private Inventario i;

    void Start()
    {
        rifle = GetComponent<Rifle>();
        i = GetComponent<Inventario>();
    }

    void Update()
    {
    }

    public void cargaPistol()
    {
        foreach (GameObject g in i.inventario)
        {
            if (g.tag.Equals("CargadorPistol"))
            {
                rifle.maxBalas += 12;
                i.inventario.Remove(g);
            }
        }
    }
    
    public void cargaRifle()
    {
        foreach (GameObject g in i.inventario)
        {
            if (g.tag.Equals("CargadorRifle"))
            {
                rifle.maxBalas += 24;
                i.inventario.Remove(g);
            }
        }
    }

   
}
