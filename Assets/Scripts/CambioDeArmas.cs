using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeArmas : MonoBehaviour
{
    [SerializeField] private List<GameObject> armas = new List<GameObject>();
    [SerializeField] private Animator animator;
    void Start()
    {
        foreach (GameObject arma in armas)
        {
            arma.SetActive(false);
        }

        if (armas.Count > 0)
        {
            armas[0].SetActive(true);
            animator.SetBool("Rifle", false);
            animator.SetBool("Pistol", true);
        }
    }

    void Update()
    {
        cambiarArma();
    }

    public void cambiarArma()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivarArma(0);
            animator.SetBool("Rifle",false);
            animator.SetBool("Pistol",true);
            animator.SetBool("Knife", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivarArma(1);
            animator.SetBool("Rifle", true);
            animator.SetBool("Pistol", false);
            animator.SetBool("Knife", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivarArma(2);
            animator.SetBool("Rifle", false);
            animator.SetBool("Pistol", false);
            animator.SetBool("Knife", true);
        }


    }
    void ActivarArma(int indice)
    {
        DesactivarTodasArmas();

        if (indice >= 0 && indice < armas.Count)
        {
            armas[indice].SetActive(true);
        }
    }

    void DesactivarTodasArmas()
    {
        foreach (GameObject arma in armas)
        {
            arma.SetActive(false);
        }
    }
}
