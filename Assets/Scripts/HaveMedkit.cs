using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HaveMedkit : MonoBehaviour
{
    [SerializeField] private RawImage image;
    [SerializeField] private Inventario inventario;
    [SerializeField] private Texture objeto;
    [SerializeField] private bool medkit;
    [SerializeField] private bool bottle;
    [SerializeField] private TextMeshProUGUI cantidad;
    

    void Start()
    {
        image.texture = null;
        image.color = new Color(255,255,255,0f);
        cantidad.text = "";
    }

  
    void Update()
    {
        if (medkit)
        {
            isMedkit();
        }
        if(bottle)
        {
            isBottle();
        }
        
    }
    public void isMedkit()
    {
        int contador = 0;
        foreach (GameObject g in inventario.inventario)
        {
            if (g.tag.Equals("Medkit"))
            {
                image.texture = objeto;
                image.color = new Color(255, 255, 255, 1f);
                contador++;
                cantidad.text = contador.ToString();
            }
      
        }
        if (contador == 0)
        {
            cantidad.text = "";
            image.texture = null;
            image.color = new Color(255, 255, 255, 0f);
        }
    }
    public void isBottle()
    {
        int contador = 0;
        foreach (GameObject g in inventario.inventario)
        {
            if (g.tag.Equals("Bottle"))
            {
                image.texture = objeto;
                image.color = new Color(255, 255, 255, 1f);
                contador++;
                cantidad.text = contador.ToString();
            }
        }
        if (contador == 0)
        {
            cantidad.text = "";
            image.texture = null;
            image.color = new Color(255, 255, 255, 0f);
        }
    }



}
