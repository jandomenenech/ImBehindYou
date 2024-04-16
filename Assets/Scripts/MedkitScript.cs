using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitScript : MonoBehaviour
{

 [SerializeField]private Inventario inv;


    void Start()
    {
    inv = GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UseMedkit(){

        foreach(GameObject t in inv.inventario){

        string[] nombre = t.name.ToString().Split("(");
        if(Input.GetKeyDown(KeyCode.Alpha5) && nombre[0].Equals("medkit")){
         //inv.nombreInventario.Remove(t);
        }
    }
    }
}
