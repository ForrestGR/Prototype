using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button mainMenuButton;

    void Start()
    {
        if (pauseMenuUI == null)
        {
            Debug.LogError("PauseMenuUI is not assigned in the inspector!");
        }
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f; // Sicherstellen, dass das Spiel normal läuft


        // Event-Listener für die Buttons hinzufügen
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(Resume);
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }

        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(LoadMenu);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);    
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Ersetze "MainMenu" durch den Namen deiner Hauptmenü-Szene
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
