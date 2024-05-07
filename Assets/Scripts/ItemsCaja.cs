using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCaja : MonoBehaviour
{
    [SerializeField] private List<Texture> imagenes;
    [SerializeField] private List<RawImage> image;
    void Start()
    {
        objetosAleatorios();
    }

    
    void Update()
    {
         
    }

    public void objetosAleatorios()
    {
        foreach (RawImage i in image)
        {
            i.texture = imagenes[Random.Range(0, imagenes.Count)];
        }
           
        
    }
}
