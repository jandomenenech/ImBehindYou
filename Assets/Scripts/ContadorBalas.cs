using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorBalas : MonoBehaviour
{
    public Rifle rifle;
    public TextMeshProUGUI text;
    public CanvaCambioArma armas;
    void Start()
    {
        text.text = rifle.balas + "/" + rifle.maxBalas;
    }

    void Update()
    {
        
        if (armas.image.texture.Equals(armas.imagenes[0]))
        {
            text.text = rifle.balas + "/" + rifle.maxBalas;
        }
        if (armas.image.texture.Equals(armas.imagenes[1]))
        {
            text.text = rifle.balasRifle + "/" + rifle.maxBalasRifle;
        }
        if (armas.image.texture.Equals(armas.imagenes[2]))
        {
            text.text = "";
        }
        
    }
}
