using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviourPun
{
    public GameObject balaPrefab;
    public GameObject puntoDeDisparo;
    public float fuerzaDeDisparo = 10f;


    [PunRPC]
    public void Disparar(Vector3 position, Quaternion rotation)
    {
        
     
        Quaternion rotacion = rotation;


        Vector3 posicionBala = position;


        GameObject bala = PhotonNetwork.Instantiate(balaPrefab.name, posicionBala, rotacion);


        Rigidbody balaRigidbody = bala.GetComponent<Rigidbody>();

        if (balaRigidbody != null)
        {

            balaRigidbody.AddForce(transform.transform.forward * fuerzaDeDisparo, ForceMode.Impulse);


            Destroy(bala, 5f);
        }
        else
        {
            Debug.LogError("El prefab de la bala no tiene un componente Rigidbody.");
        }
    }


private void OnCollisionEnter(Collision collision)
    {
       /* if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);

        }*/
    }


}
