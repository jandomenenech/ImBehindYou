using UnityEngine;
using TMPro;

public class StaminaSystem : MonoBehaviour
{
    public float stamina = 100f;
    public float maxStamina = 100f;
    public float staminaDecreaseRate = 10f;
    public float staminaIncreaseRate = 5f;
    public float recoveryDelay = 2f;
    public float zeroStaminaDuration = 5f; // Duration of the special velocity state when stamina is zero
    public float normalSpeed = 200f; // Normal run velocity
    public float zeroStaminaSpeed = 100f; // Velocity when stamina reaches zero

    private float recoveryTimer = 0f;
    private float zeroStaminaTimer = 0f;
    private bool isZeroStaminaSpeed = false;

    public TextMeshProUGUI staminaText; // Reference to the TextMeshPro object displaying stamina

    [SerializeField] private Inventario inv;
    void Start()
    {
        UpdateStaminaText();
    }

    void Update()
    {
        // Sprinting mechanics
        if (Input.GetKey(KeyCode.LeftShift) && CanSprint())
        {
            stamina -= staminaDecreaseRate * Time.deltaTime;
            if (stamina < 0)
            {
                stamina = 0;
                recoveryTimer = recoveryDelay; // Reset the recovery timer when stamina reaches zero
                zeroStaminaTimer = zeroStaminaDuration; // Start the timer for the zero stamina speed state
                isZeroStaminaSpeed = true; // Set the flag for zero stamina speed state
            }
        }
        else
        {
            // Increase stamina
            stamina += staminaIncreaseRate * Time.deltaTime;
            if (stamina > maxStamina)
                stamina = maxStamina;

            // Start recovery timer when stamina starts increasing
            if (stamina > 0)
            {
                recoveryTimer -= Time.deltaTime;
                if (recoveryTimer <= 0)
                {
                    recoveryTimer = 0; // Ensure the timer doesn't go below zero
                }
            }
            useBottle();
        }

        // Update the zero stamina speed state
        if (isZeroStaminaSpeed)
        {
            zeroStaminaTimer -= Time.deltaTime;
            if (zeroStaminaTimer <= 0)
            {
                zeroStaminaTimer = 0; // Ensure the timer doesn't go below zero
                isZeroStaminaSpeed = false; // Reset the flag for zero stamina speed state
            }
        }

        UpdateStaminaText();
    }

    void UpdateStaminaText()
    {
        if (staminaText != null)
        {
            staminaText.text = Mathf.RoundToInt(stamina).ToString();
        }
    }

    public bool CanSprint()
    {
        return stamina > 0 && recoveryTimer <= 0f;
    }

    public float GetSpeed()
    {
        if (isZeroStaminaSpeed)
        {
            Debug.Log("Cant sprint");
            return zeroStaminaSpeed;
        }
        else
        {
            return normalSpeed;
        }
    }

public void IncreaseStamina(float amount)
{
    stamina += amount;
    if (stamina > maxStamina)
        stamina = maxStamina;

    // Reset the recovery timer when stamina starts increasing
    if (stamina > 0)
    {
        recoveryTimer = recoveryDelay;
    }
}
    void useBottle()
    {
     int contador  = 0;
     if(Input.GetKeyDown(KeyCode.Alpha5))
     {
        foreach(GameObject obj in inv.inventario)
        {
        if (obj.CompareTag("Bottle"))
        {
            IncreaseStamina(40);
            inv.inventario.Remove(obj);
            Destroy(obj);
            foreach(GameObject i in inv.inventario)
            {
               if(i.tag.Equals("Bottle") && contador != 1)
               {
                 
                contador = 1;
               }
            }
            break;
        }
        }
     } else{

     }
    }
}
