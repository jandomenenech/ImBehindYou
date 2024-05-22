using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject pausa;
    private int contador;
    
    void Start()
    {
        contador = 0;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (contador == 0)
            {
                pausa.SetActive(true);
                contador = 1;
            }
            else
            {
                pausa.SetActive(false);
                contador = 0;
            }
            
        }
    }

    public void seguir()
    {
        pausa.SetActive(false);
    }

    public void volver()
    {
        SceneManager.LoadScene("Menu");
    }
}
