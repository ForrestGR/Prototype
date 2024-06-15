using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Button restartButton;

    void Start()
    {
        gameOverScreen.SetActive(false); // Verstecke den Game Over Screen zu Beginn des Spiels
        restartButton.onClick.AddListener(RestartGame);
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Lade die aktuelle Szene neu
    }
}
