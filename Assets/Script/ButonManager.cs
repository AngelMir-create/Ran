using UnityEngine;
using UnityEngine.SceneManagement;

public class ButonManager : MonoBehaviour
{
    public GameObject startMenuPanel;

    private void Start()
    {
        
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
        }
        else
        {
            Debug.LogWarning("StartMenuPanel не назначен в Инспекторе!");
        }
    }
}
