using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] private Bala bala;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        disparar();
    }

    public void disparar()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            bala.Disparar();
            Debug.Log("Disparo");
        }
    }
}
