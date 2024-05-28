using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCodo : MonoBehaviour
{
    public Transform target; 
    private Vector3 initialOffset; 
    private bool offsetCalculated = false;

    void Start()
    {
        CalculateOffset();
    }

    void Update()
    {
        if (target != null)
        {
            if (!offsetCalculated)
            {
                CalculateOffset();
            }

            
            transform.position = target.position + initialOffset;
            transform.rotation = target.rotation;
        }
    }

    void CalculateOffset()
    {
        if (target != null)
        {
            
            initialOffset = transform.position - target.position;
            offsetCalculated = true;
        }
    }

    public void UpdateTarget(Transform newTarget)
    {
        target = newTarget;
        offsetCalculated = false;
    }
}
