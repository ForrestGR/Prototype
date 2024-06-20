using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{


    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    public AudioClip sceneMusic;

    private void Start()
    {
        if (sceneMusic != null)
        {
            MusicManager.Instance.PlayMusic(sceneMusic);
        }
    }


    private void Awake()
    {
        playButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.TopDownScene);
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });

        Time.timeScale = 1f;
    }

}