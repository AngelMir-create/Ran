using UnityEngine;
using UnityEngine.SceneManagement;

public class ButonManager : MonoBehaviour
{
    public GameObject startMenuPanel;
    private AudioSource audioSource;
    public AudioClip Sound_01;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 0f;
    }

    public void OnStartButtonClicked()
    {
        HideStartMenu();
        //SceneManager.LoadScene("Sample Scene");
    }

    private void HideStartMenu()
    {
        if (startMenuPanel != null)
        {
            startMenuPanel.SetActive(false);
            Time.timeScale = 1f;
            audioSource.PlayOneShot(Sound_01, 1f);
        }
        else
        {
            Debug.LogWarning("StartMenuPanel не назначен в Инспекторе!");
        }
    }

    public void ButtonRestart()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        audioSource.PlayOneShot(Sound_01, 1f);
    }
}
