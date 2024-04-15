using UnityEngine.Video;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubtituloInicio : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI subtitulo;
    [SerializeField] private GameObject titulo;
    [SerializeField] private VideoPlayer video;
    [SerializeField] private GameObject jugar;
    [SerializeField] private GameObject practica;
    [SerializeField] private GameObject inventario;
    [SerializeField] private GameObject configuracion;
    [SerializeField] private GameObject salir;
    [SerializeField] private VideoPlayer videoMenu;



    private float time;
    private bool subt;
    private Color medio = new Color(255, 255, 255, 0.5f);
    private Color completo = new Color(255, 255, 255, 1f);
    private Color desaparecido = new Color(255, 255, 255, 0f);

    void Start()
    {
        jugar.SetActive(false);
        inventario.SetActive(false);
        salir.SetActive(false);
        configuracion.SetActive(false);
        practica.SetActive(false);
        video.gameObject.SetActive(true);
        titulo.SetActive(true);
        video.gameObject.SetActive(true);
        videoMenu.gameObject.SetActive(false);
        subtitulo.gameObject.SetActive(true);

        subt = true;
        time = Time.deltaTime;

        subtitulo.color = completo;
    }

    void Update()
    {
        pulsaTecla();
        
    }

    void pulsaTecla()
    {
        if (Input.anyKeyDown)
        {
            subtitulo.gameObject.SetActive(false);
            titulo.SetActive(false);
            video.gameObject.SetActive(false);
            jugar.SetActive(true);
            inventario.SetActive(true);
            salir.SetActive(true);
            configuracion.SetActive(true);
            practica.SetActive(true);
            videoMenu.gameObject.SetActive(true);
        }
        else
        {
            parpadeoSubtitulo();
        }
    }

    void parpadeoSubtitulo()
    {
        if (time + 1 < Time.time && subtitulo.color.Equals(completo))
        {

            time = Time.time;
            subtitulo.color = medio;
            
        }
        else if (time + 0.10 < Time.time && subtitulo.color.Equals(medio))
        {

            time = Time.time;
            subtitulo.color = desaparecido;
  
        }
        else if (time + 0.25 < Time.time && subtitulo.color.Equals(desaparecido))
        {

            time = Time.time;
            subtitulo.color = completo;
        }
    }

    public void campoDeTiro()
    {
        SceneManager.LoadScene("ShootingRange");
    }

    public void playing()
    {
        SceneManager.LoadScene("Mapa");
    }
    public void exit()
    {
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        }
    }
}
