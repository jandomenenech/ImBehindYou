using Photon.Pun;
using UnityEngine;

public class Bala : MonoBehaviourPunCallbacks
{
    public GameObject balaPrefab;
    public float fuerzaDeDisparo = 10f;

    [PunRPC]
    public void Disparar(Vector3 position, Quaternion rotation)
    {
        GameObject bala = PhotonNetwork.Instantiate(balaPrefab.name, position, rotation);

        Rigidbody balaRigidbody = bala.GetComponent<Rigidbody>();
        if (balaRigidbody != null)
        {
            balaRigidbody.AddForce(bala.transform.forward * fuerzaDeDisparo, ForceMode.Impulse);
            Destroy(bala, 5f); 
        }
        else
        {
            Debug.LogError("El prefab de la bala no tiene un componente Rigidbody.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (photonView.IsMine)
            {
                PhotonView targetView = collision.collider.GetComponent<PhotonView>();
                if (targetView != null)
                {
                    photonView.RPC("ApplyDamage", RpcTarget.All, targetView.ViewID, 30);
                }
            }
            PhotonNetwork.Destroy(gameObject);
        }
    }

    [PunRPC]
    public void ApplyDamage(int viewID, int damage)
    {
        PhotonView targetView = PhotonView.Find(viewID);
        if (targetView != null)
        {
            HealthSystem healthSystem = targetView.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.DecreaseHealth(damage);
            }
        }
    }
}
