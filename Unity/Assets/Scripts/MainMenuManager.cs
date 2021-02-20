using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Button PlayB;
    public Button QuitB;
    public Button MPB;

    private void Start()
    {
        PlayB.onClick.AddListener(PlayGame);
        QuitB.onClick.AddListener(QuitGame);
        MPB.onClick.AddListener(GoMultiplayer);
    }

    void PlayGame()
    {
        SceneManager.LoadScene(6);
    }

    void GoMultiplayer()
    {
        SceneManager.LoadScene(3);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}