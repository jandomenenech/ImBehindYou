using UnityEngine;
using UnityEngine.Animations.Rigging;
using System.Collections.Generic;

public class CambioDeArmas : MonoBehaviour
{
    [SerializeField] private List<GameObject> armas = new List<GameObject>();
    [SerializeField] private Animator animator;
    [SerializeField] private RigBuilder rigBuilder;


    private int currentWeaponIndex = 0;

    void Start()
    {
        for (int i = 0; i < armas.Count; i++)
        {
            armas[i].SetActive(false);
        }

        if (armas.Count > 0)
        {
            armas[0].SetActive(true);
     
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
            animator.SetBool("Pistol", true);
            animator.SetBool("Rifle", false);
            animator.SetBool("Knife", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivarArma(1);
            animator.SetBool("Pistol", false);
            animator.SetBool("Rifle", true);
            animator.SetBool("Knife", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivarArma(2);
            animator.SetBool("Pistol", false);
            animator.SetBool("Rifle", false);
            animator.SetBool("Knife", true);
        }
    }

    void ActivarArma(int indice)
    {
        if (indice >= 0 && indice < armas.Count)
        {
            armas[currentWeaponIndex].SetActive(false);
            armas[indice].SetActive(true);
            currentWeaponIndex = indice;

        }
    }

   
}
