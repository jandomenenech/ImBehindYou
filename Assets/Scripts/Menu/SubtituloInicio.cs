using UnityEngine.Video;
using UnityEngine;

public class SubtituloInicio : MonoBehaviour
{
    [SerializeField] public GameObject subtitulo;
    [SerializeField] public GameObject titulo;
    [SerializeField] private VideoPlayer video;

    void Start()
    {
 
    }

    void Update()
    {
        PulsaTecla();
    }

    void PulsaTecla()
    {
        if (Input.anyKeyDown)
        {
            subtitulo.SetActive(false);
            titulo.SetActive(false);
            video.gameObject.SetActive(false);
        }
    }
}
