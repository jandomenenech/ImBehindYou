using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MostrarInvCaja : MonoBehaviour
{
    [SerializeField] private List<RawImage> imagenes;
    [SerializeField] private List<Texture> items;
    [SerializeField]private List<Texture> objetos;
    
     
    void Start()
    {
        actualizarInventario();
    }


    void Update()
    {
        actualizarInventario();
    }

    public void mostrarInventario(List<GameObject> lista)
    {
        objetos.Clear();
        foreach (GameObject a in lista)
        {
            if (a.tag.Equals("Medkit"))
            {
                objetos.Add(items[0]);
            }
            else if (a.tag.Equals("Bottle"))
            {
                objetos.Add(items[1]);
            }
            else if (a.tag.Equals("CargadorPistol"))
            {
                objetos.Add(items[2]);
            }
            else if (a.tag.Equals("CargadorRifle"))
            {
                objetos.Add(items[3]);
            }
            else
            {
                objetos.Add(null);
            }
        }

    }

    public void actualizarInventario()
    {
        for (int i = 0; i < imagenes.Count; i++)
        {
            imagenes[i].texture = objetos[i];
        }
    }
}
