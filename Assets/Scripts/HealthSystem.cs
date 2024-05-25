using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviourPunCallbacks, IPunObservable
{
    public int maxHealth = 100;
    public int currentHealth;
    [SerializeField] private Animator animator;

    public TextMeshProUGUI healthText;

    [SerializeField] private Inventario inv;
    [SerializeField] private GameObject player;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    void Update()
    {
        estasVivo();
        if (Input.GetKeyDown(KeyCode.P))
        {
            DecreaseHealth(12);
        }
        UseMedkit();
        UseTin();
    }

    [PunRPC]
    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            photonView.RPC("PlayDeathAnimation", RpcTarget.All);
        }
        UpdateHealthText();
    }

    [PunRPC]
    void PlayDeathAnimation()
    {
        animator.SetTrigger("Muerte");
        if (photonView.IsMine)
        {
            DisablePlayerScripts();
        }
    }

    public void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthText();
    }

    void UseMedkit()
    {
        int contador = 0;

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (GameObject obj in inv.inventario)
            {
                if (obj.CompareTag("Medkit"))
                {
                    IncreaseHealth(40);
                    inv.inventario.Remove(obj);
                    Destroy(obj);
                    foreach (GameObject g in inv.inventario)
                    {
                        if (g.tag.Equals("Medkit") && contador != 1)
                        {
                            contador = 1;
                        }
                    }
                    break;
                }
            }
        }
    }

    void estasVivo()
    {
        if (currentHealth <= 0)
        {
            photonView.RPC("PlayDeathAnimation", RpcTarget.All);
        }
    }

    void UseTin()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            for (int i = 0; i < inv.inventario.Count; i++)
            {
                GameObject obj = inv.inventario[i];
                if (obj.CompareTag("Tin"))
                {
                    IncreaseHealth(15);
                    inv.inventario.RemoveAt(i);
                    Destroy(obj);

                    
                    for (int j = 0; j < inv.nombreInventario.Count; j++)
                    {
                        RawImage g = inv.nombreInventario[j];
                        if (g.texture != null && g.texture.name.Equals("tin"))
                        {
                            g.texture = null;
                            g.color = new Color(255, 255, 255, 0f); 
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }


    void DisablePlayerScripts()
    {
        MonoBehaviour[] scripts = player.GetComponentsInChildren<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts)
        {
            if (script != this) // No desactivar este script
            {
                script.enabled = false;
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Enviar datos
            stream.SendNext(currentHealth);
        }
        else
        {
            // Recibir datos
            currentHealth = (int)stream.ReceiveNext();
            UpdateHealthText();
        }
    }
}