using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera topDownCamera; // Deine Top-Down-Kamera
    public Camera firstPersonCamera; // Deine First-Person-Kamera
    private bool isTopDown = true; // Start in der Top-Down-Ansicht

    void Start()
    {
        // Stelle sicher, dass nur die Top-Down-Kamera anfangs aktiv ist
        topDownCamera.gameObject.SetActive(true);
        firstPersonCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        // Wechseln der Kameraansicht, wenn die Taste "C" gedrückt wird
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        if (isTopDown)
        {
            topDownCamera.gameObject.SetActive(false);
            firstPersonCamera.gameObject.SetActive(true);
            isTopDown = false;
        }
        else
        {
            topDownCamera.gameObject.SetActive(true);
            firstPersonCamera.gameObject.SetActive(false);
            isTopDown = true;
        }
    }
}
