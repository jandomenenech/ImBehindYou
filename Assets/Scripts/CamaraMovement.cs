using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    public Transform target; // Objeto a seguir
    public float distance = 5.0f; // Distancia de la cámara al objetivo
    public float height = 3.0f; // Altura de la cámara sobre el objetivo
    public float smoothSpeed = 0.125f; // Velocidad de suavizado de la cámara

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, height, -distance);
    }

    void LateUpdate()
    {
        if (!target)
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}



