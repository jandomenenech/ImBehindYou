using UnityEngine;
using TMPro;

public class HeadbandScript : MonoBehaviour
{
    public Light headLight; // Reference to the Light component
    public TextMeshProUGUI batteryText; // Reference to the TextMeshPro component

    private bool isLightOn = false;
    private float lastToggleTime;
    private const float batteryLife = 40f; // in seconds
    private const float blinkThreshold = 20f; // in seconds, when the light should start blinking
    private int blinkCount = 0; // Number of times the light has blinked

    private float remainingBattery;

    void Start()
    {
        remainingBattery = 40f;
        if (headLight == null)
        {
            Debug.LogError("No Light component assigned to HeadbandController.");
        }
        else
        {
            // Turn off the light by default
            headLight.enabled = false;
        }

        if (batteryText == null)
        {
        }
    }

    void Update()
    {
        // Toggle light on 'L' key press
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleLight();
        }

        // Check if the light is on
        if (isLightOn)
        {
            // Check if it's time to turn off the light
            if (Time.time - lastToggleTime >= batteryLife)
            {
                TurnOffLight();
            }
            else if (Time.time - lastToggleTime >= blinkThreshold && blinkCount < 4 && !IsInvoking("BlinkLight"))
            {
                // Start blinking if battery life is less than 20 seconds, the blink count is less than 4,
                // and blinking isn't already happening
                InvokeRepeating("BlinkLight", 0f, 0.5f);
            }

            // Update battery countdown text
            remainingBattery = batteryLife - (Time.time - lastToggleTime);
            batteryText.text = "Battery left:" + Mathf.RoundToInt(remainingBattery) + " s";

            // Debug log for battery life less than 40 seconds
            if (remainingBattery <= 40f)
            {
                Debug.Log("Battery life: " + remainingBattery + " seconds");
            }
        }
    }

    void ToggleLight()
    {
        isLightOn = !isLightOn;
        if (isLightOn)
        {
            headLight.enabled = true;
            lastToggleTime = Time.time;
        }
        else
        {
            TurnOffLight();
        }
    }

    void TurnOffLight()
    {
        headLight.enabled = false;
        isLightOn = false;
        CancelInvoke("BlinkLight"); // Cancel blinking
        blinkCount = 0; // Reset blink count
        batteryText.text = ""; // Clear battery countdown text
    }

    void BlinkLight()
    {
        headLight.enabled = !headLight.enabled;
        blinkCount++;

        // If blinked 4 times, stop blinking8
        if (blinkCount >= 4)
        {
            CancelInvoke("BlinkLight");
            Debug.Log("Blink count: " + blinkCount);
        }
    }
}
