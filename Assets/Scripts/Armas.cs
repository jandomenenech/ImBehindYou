using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField] private Rifle rifle;
    private float time;
    [SerializeField] private Bala bala;
    void Start()
    {
        time = Time.time;
    }

    void Update()
    {
       // rifle.disparar();
        //rifle.recargar();
    }
}
