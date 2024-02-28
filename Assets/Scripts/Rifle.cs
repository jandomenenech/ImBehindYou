using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] private Bala bala;
    private float tiempoDisparo;
    void Start()
    {
        tiempoDisparo = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        disparar();
    }

    public void disparar()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && tiempoDisparo + 0.4f < Time.time)
        {
            bala.Disparar();
            Debug.Log("Disparo");
            tiempoDisparo = Time.time;
        }
    }
}
