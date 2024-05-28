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
    }

    void Update()
    {
        cambiarArma();
    }

    public void cambiarArma()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetBool("Pistol", true);
        }

    }


   
}
