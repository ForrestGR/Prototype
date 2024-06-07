using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Lädt die Spielszene
        SceneManager.LoadScene("GameScene"); // Ersetze "GameScene" durch den Namen deiner Spielszene
    }

    public void QuitGame()
    {
        // Beendet das Spiel
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
