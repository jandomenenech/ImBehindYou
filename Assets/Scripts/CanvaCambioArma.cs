using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvaCambioArma : MonoBehaviour
{
    [SerializeField] public Texture[] imagenes;
    [SerializeField] public RawImage image;

    void Start()
    {
        image.texture = imagenes[0];
    }

    // Update is called once per frame
    void Update()
    {
        cambiarImagen();
    }

    void cambiarImagen()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            image.texture = imagenes[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            image.texture = imagenes[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            image.texture = imagenes[2];
        }
    }
}
