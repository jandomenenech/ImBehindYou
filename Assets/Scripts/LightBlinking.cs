using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    public Light lightToBlink;
    public float minInterval = 0.1f; // Minimum interval
    public float maxInterval = 2.0f; // Maximum interval

    private void Start()
    {
        // Start the blinking coroutine
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            // Toggle the light on and off
            lightToBlink.enabled = !lightToBlink.enabled;

            // Generate a random interval between minInterval and maxInterval
            float randomInterval = Random.Range(minInterval, maxInterval);

            // Wait for the random interval
            yield return new WaitForSeconds(randomInterval);
        }
    }
}
