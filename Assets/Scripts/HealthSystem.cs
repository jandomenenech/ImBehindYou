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
    public TextMeshProUGUI maxHealthText; // TextMeshPro for displaying max health

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        UpdateMaxHealthText(); // Call to update max health text on start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DecreaseHealth(12); // Decrease health by 12 when P is pressed
        }
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
        maxHealthText.text = maxHealth.ToString(); // Update max health text
    }

    void EndGame()
    {
        Debug.Log("Gameover");
        
    }
}