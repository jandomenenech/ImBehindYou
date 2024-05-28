using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class TargetMovment : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 offset = new Vector3(0f, 0f, 2f);
    private void Start()
    {
        transform.position = cameraTransform.position + cameraTransform.TransformDirection(offset);
        transform.rotation = cameraTransform.rotation;
    }

    void Update()
    {

        transform.position = cameraTransform.position + cameraTransform.TransformDirection(offset);
        transform.rotation = cameraTransform.rotation;
    }
}