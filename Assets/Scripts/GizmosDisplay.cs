using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class GizmosDisplay : MonoBehaviour
{


    public TMP_Text fpstext;


    void Update()
    {
        float fps = 1.0f / Time.deltaTime;
        fpstext.text = "FPS " + Mathf.Round(fps);

       
    }
}
