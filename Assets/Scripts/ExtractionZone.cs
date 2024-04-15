using UnityEngine;
using TMPro;

public class ExtractionZone : MonoBehaviour
{
    public float extractionTime = 10f;
    private float timer = 0f;
    private bool isCharacterInside = false;

    public TMP_Text countdownText; // Reference to the TextMeshPro UI element

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCharacterInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCharacterInside = false;
            timer = 0f;
            UpdateCountdownText(); // Clear countdown text when player exits
        }
    }

    private void Update()
    {
        if (isCharacterInside)
        {
            timer += Time.deltaTime;
            UpdateCountdownText();

            if (timer >= extractionTime)
            {
                countdownText.text = "EXTRACTION COMPLETED!";
                EndGame();
            }
        }
    }

    private void UpdateCountdownText()
    {
        if (countdownText != null)
        {
            float timeRemaining = Mathf.Max(extractionTime - timer, 0f);
            countdownText.text = timeRemaining.ToString("F1") + "S";
        }
    }

    private void EndGame()
    {
        Debug.Log("Victory Extraction complete");
        // You can add more logic here for game ending
    }
}
