using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCaja : MonoBehaviour
{
    [SerializeField] private List<Texture> imagenes;
    [SerializeField] private RawImage image;
    void Start()
    {
        
    }

    
    void Update()
    {
         
    }

    public void objetosAleatorios()
    {
        foreach (Texture tex in imagenes)
        {
           image.texture = tex;
        }
    }
}
