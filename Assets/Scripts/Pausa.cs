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

    
    void Start()
    {
        
    }

    
    void Update()
    {
       
    }

    public void seguir()
    {
        pausa.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    

   
}
