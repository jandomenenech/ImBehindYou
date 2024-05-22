using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDeDisparo;
    public float fuerzaDeDisparo = 10f;
    public GameObject player;


    private void Start()
    {

    }
    public void Disparar()
    {
        Quaternion rotacion = Quaternion.Euler(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z);
        Vector3 offset = new Vector3(0f, 0f, 3f); 

        Vector3 posicionBala = puntoDeDisparo.position + puntoDeDisparo.forward * offset.z;

        GameObject bala = Instantiate(balaPrefab, posicionBala, rotacion);

        Rigidbody balaRigidbody = bala.GetComponent<Rigidbody>();

        if (balaRigidbody != null)
        {
            balaRigidbody.AddForce(puntoDeDisparo.forward * fuerzaDeDisparo, ForceMode.Impulse);

            Destroy(bala, 5f);
        }
        else
        {
            Debug.LogError("El prefab de la bala no tiene un componente Rigidbody.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);

        }
    }


}
