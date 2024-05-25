using UnityEngine;
using UnityEngine.Animations.Rigging;
using System.Collections.Generic;

public class CambioDeArmas : MonoBehaviour
{
    [SerializeField] private List<GameObject> armas = new List<GameObject>();
    [SerializeField] private List<RuntimeAnimatorController> animators = new List<RuntimeAnimatorController>();
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
            animator.runtimeAnimatorController = animators[0];
     
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
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivarArma(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivarArma(2);
        }
    }

    void ActivarArma(int indice)
    {
        if (indice >= 0 && indice < armas.Count)
        {
            armas[currentWeaponIndex].SetActive(false);
            armas[indice].SetActive(true);

            animator.runtimeAnimatorController = animators[indice];
            currentWeaponIndex = indice;

        }
    }

   
}
