using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject victoria;
    public GameObject derrota;
    public GameObject[] objetos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void FinPartida(bool win)
    {
        obtenerObjetos();
        
        if (win)
        {
            victoria.SetActive(true);
            
        }
        else if(!win)
        {
            derrota.SetActive(true);
        }
    }

    void obtenerObjetos()
    {
        foreach (GameObject g in objetos)
        {
            g.SetActive(false);
        }
    }
}

