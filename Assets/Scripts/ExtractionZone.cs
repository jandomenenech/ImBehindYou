using UnityEngine;
using TMPro;
using UnityEngine.Playables;
using Photon.Pun;
using System.Collections;

public class ExtractionZone : MonoBehaviourPunCallbacks, IPunObservable
{
    public float extractionTime = 10f;
    private float timer = 0f;
    private bool isCharacterInside = false;
    private PhotonView playerInsideView = null;

    public TMP_Text countdownText; // Reference to the TextMeshPro UI element
    public Animator ani;
    public GameObject cinematicCamera; // Camera used for the cinematic
    public AudioClip alarmClip; // Reference to the alarm audio clip
    private AudioSource audioSource; // Reference to the AudioSource component

    private bool didWin = false;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = alarmClip;
        audioSource.loop = true; // Set the audio to loop
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCharacterInside = true;
            playerInsideView = other.GetComponent<PhotonView>();

            // Play the alarm sound
            if (audioSource != null && alarmClip != null)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCharacterInside = false;
            timer = 0f;
            UpdateCountdownText();
            countdownText.gameObject.SetActive(false); // Clear countdown text when player exits
            playerInsideView = null;

            // Stop the alarm sound
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }

    private void Update()
    {
        if (isCharacterInside)
        {
            countdownText.gameObject.SetActive(true);
            timer += Time.deltaTime;
            UpdateCountdownText();

            if (timer >= extractionTime)
            {
                countdownText.text = "EXTRACTION COMPLETED!";
                EndGame();
                OnPlayableDirectorStopped();
            }
        }
    }

    private void UpdateCountdownText()
    {
        if (countdownText != null)
        {
            float timeRemaining = Mathf.Max(extractionTime - timer, 0f);
            countdownText.text = timeRemaining.ToString("F1") + "S";
        }
    }

    public void EndGame()
    {
        photonView.RPC("PlayCinematic", RpcTarget.All);
    }

    [PunRPC]
    public void PlayCinematic()
    {
        Debug.Log("PlayCinematic RPC called");

        // Deactivate all player cameras
        GameObject[] playerCameras = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerCamera in playerCameras)
        {
            Camera cameraComponent = playerCamera.GetComponentInChildren<Camera>();
            if (cameraComponent != null)
            {
                cameraComponent.gameObject.SetActive(false);
                Debug.Log("Player camera deactivated");
            }
        }

        // Activate cinematic camera
        if (cinematicCamera != null)
        {
            cinematicCamera.SetActive(true);
            Debug.Log("Cinematic camera activated");
        }
        else
        {
            Debug.LogError("Cinematic camera is not assigned");
        }
        ani.SetTrigger("Fin");
    }

    private void OnPlayableDirectorStopped()
    {
        StartCoroutine(CallFinPartidaAfterDelay(5f));
    }

    private IEnumerator CallFinPartidaAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        photonView.RPC("SetGameResult", RpcTarget.All);
    }

    [PunRPC]
    public void SetGameResult()
    {
        bool isLocalPlayerWinner = playerInsideView != null && playerInsideView.IsMine;
        GameManager.Instance.FinPartida(isLocalPlayerWinner);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // Aquí puedes añadir lógica para sincronizar datos si es necesario
    }
}
