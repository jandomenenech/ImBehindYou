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
        Quaternion rotacion = Quaternion.Euler(90f, 0f, 0f);
        GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position,rotacion);

        Rigidbody balaRigidbody = bala.GetComponent<Rigidbody>();

        if (balaRigidbody != null)
        {
            balaRigidbody.AddForce(-puntoDeDisparo.forward * fuerzaDeDisparo, ForceMode.Impulse);

            Destroy(bala, 5f);
        }
        else
        {
            Debug.LogError("El prefab de la bala no tiene un componente Rigidbody.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemigo Golpeado");
            Destroy(gameObject);
        }
    }
}
