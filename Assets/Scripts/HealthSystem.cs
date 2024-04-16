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
    public TextMeshProUGUI maxHealthText;

    [SerializeField] private Inventario inv;



    void Start()
    {
        currentHealth = maxHealth;
        UpdateMaxHealthText();
        inv = GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>();

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            DecreaseHealth(12);
        }
        UseMedkit();
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

    void UpdateMaxHealthText()
    {
        maxHealthText.text = maxHealth.ToString();
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
    
    
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

             foreach(GameObject obj in inv.inventario)
            {
                if(obj.CompareTag("Medkit")){
                   IncreaseHealth(40);
                }
            }
            // inv.inventario.Remove(obj); // Opcional: elimina el medkit del inventario
        }
        else {
            Debug.Log("No se cura");
        }
   
}


}
