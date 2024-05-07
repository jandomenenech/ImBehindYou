using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCaja : MonoBehaviour
{
    [SerializeField] private List<GameObject> objetosAletorios;
    [SerializeField] private List<GameObject> objetoCaja;
    [SerializeField] public List<Texture> imagenes;
    [SerializeField] private List<RawImage> image;
    void Start()
    {
        for (int i = 0; i < image.Count; i++)
        {
            objetosAleatorios(itemAleatorio());
        }
        
    }

    
    void Update()
    {
        
    }

    public void objetosAleatorios(int numero)
    {
        int contador = 0;
        foreach (RawImage i in image)
        {
            if (i.texture == null && contador!=1)
            {
                i.texture = imagenes[numero];
                contador = 1;
            }
           
        }
    }

    public int itemAleatorio()
    {
        int numero = Random.Range(0, objetosAletorios.Count);
        objetoCaja.Add(objetosAletorios[numero]);
        return numero;
    }

    public void objetosCaja()
    {
        for (int i = 0; i < image.Count; i++)
        {
            if (objetoCaja[i].tag.Equals("Medkit"))
            {
                image[i].texture = imagenes[0]; 
            }
            if (objetoCaja[i].tag.Equals("Bottle"))
            {
                image[i].texture = imagenes[2];
            }
            if (objetoCaja[i].tag.Equals("CargadorPistol"))
            {
                image[i].texture = imagenes[3];
            }
            if (objetoCaja[i].tag.Equals("CargadorRifle"))
            {
                image[i].texture = imagenes[1];
            }

        }
    }
}
