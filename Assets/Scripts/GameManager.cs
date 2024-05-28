using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
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

    private void Update()
    {
        if(derrota.activeInHierarchy || victoria.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
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

    public void obtenerObjetos()
    {
        foreach (GameObject g in objetos)
        {
            g.SetActive(false);
        }
    }

    public void volverMenu()
    {
        StartCoroutine(DisconnectAndLoadMenu());
    }

    private IEnumerator DisconnectAndLoadMenu()
    {
        Launcher.Instance.DisconnectAndGoToMenu();
        Debug.Log("Inicio de la desconexión de Photon...");

        while (PhotonNetwork.IsConnected)
        {
            Debug.Log("Esperando desconexión...");
            yield return null;
        }

        Debug.Log("Desconectado de Photon.");
        SceneManager.LoadScene(0);
    }

    

}

