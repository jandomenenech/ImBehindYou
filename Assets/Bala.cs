using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
     public GameObject balaPrefab; 
     public Transform puntoDeDisparo; 
     public float fuerzaDeDisparo = 10f;
    private float tiempo;


    private void Start()
    {
        
    }
    public void Disparar()
        {
           
            GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);

            
            Rigidbody balaRigidbody = bala.GetComponent<Rigidbody>();
        
  
            if (balaRigidbody != null)
            {
                
                balaRigidbody.AddForce(puntoDeDisparo.forward * fuerzaDeDisparo, ForceMode.Impulse);
            
            }
            else
            {
                Debug.LogError("El prefab de la bala no tiene un componente Rigidbody.");
            }

            
        }
    }
