using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuerte : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bala")
        {
            if (healthSystem != null)
            {
                healthSystem.DecreaseHealth(30);
            }
            else
            {
                Destroy(gameObject);    
            }
           
        }
    }
}
