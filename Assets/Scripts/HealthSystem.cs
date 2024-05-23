using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class HealthSystem : MonoBehaviour
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
        UpdateHealthText();
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            
        }
        UpdateHealthText();

    }

    public void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();
    }



    void EndGame()
    {
        animator.SetTrigger("Muerte");
        DisablePlayerScripts();
        
    }



    void IncreaseHealth(int amount)
    {
    currentHealth += amount;
    if(currentHealth > maxHealth)
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

             foreach(GameObject obj in inv.inventario)
            {
                if(obj.CompareTag("Medkit")){
                   IncreaseHealth(40);
                   inv.inventario.Remove(obj);
                   Destroy(obj);
                   foreach (GameObject g  in inv.inventario)
                   {

                    if(g.tag.Equals("Medkit") && contador != 1)
                    {
                        contador = 1;
                    }
                   }
                   break;
                }
            }

        }
        else {

        }
   
}

    void estasVivo()
    {
        if(currentHealth <= 0)
        {
            EndGame();
        }
    }


void UseTin()
{
    int contador = 0;
    
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {

             foreach(GameObject obj in inv.inventario)
            {
                if(obj.CompareTag("Tin")){
                   IncreaseHealth(15);
                   inv.inventario.Remove(obj);
                   Destroy(obj);
                   foreach (GameObject i in inv.inventario)
                   {

                    if(i.tag.Equals("Tin") && contador != 1)
                    {
                        contador = 1;
                    }
                   }
                   break;
                }
            }

        }
        else {
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

}
