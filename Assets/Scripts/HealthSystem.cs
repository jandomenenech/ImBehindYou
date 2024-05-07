using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public TextMeshProUGUI healthText;

    [SerializeField] private Inventario inv;



    void Start()
    {
        currentHealth = maxHealth;


    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            DecreaseHealth(12);
        }
        UseMedkit();
        UseTin();
    }

    void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthText();

        if (currentHealth == 0)
        {
            EndGame();
        }
    }

    void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();
    }



    void EndGame()
    {
        Debug.Log("Game Over");
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
            // inv.inventario.Remove(obj); // Opcional: elimina el medkit del inventario
        }
        else {
            Debug.Log("No se cura");
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
            // inv.inventario.Remove(obj); // Opcional: elimina el medkit del inventario
        }
        else {
            Debug.Log("No se cura");
        }
   
}


}
