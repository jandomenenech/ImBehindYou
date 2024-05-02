using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorBalas : MonoBehaviour
{
    public Rifle rifle;
    public TextMeshProUGUI text;
    void Start()
    {
        text.text = rifle.balas + "/" + rifle.maxBalas;
    }

    void Update()
    {
        text.text = rifle.balas + "/" + rifle.maxBalas;
    }
}
