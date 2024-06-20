using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerButton : MonoBehaviour
{
    public string sceneName = "FPSScene";

    private void OnTriggerEnter(Collider other)
    {
        // �berpr�fe, ob der kollidierende Gegenstand der Spieler ist
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
