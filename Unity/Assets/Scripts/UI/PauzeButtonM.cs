using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauzeButtonM : MonoBehaviour
{
    public Button ResumeB;
    public Button MainMenuB;
    public Button QuitGameB;

    private PauzeManager pmanager;
    private void Start()
    {
        pmanager = FindObjectOfType<PauzeManager>();
    }

    private void OnEnable()
    {
        ResumeB.onClick.AddListener(ResumeGame);
        MainMenuB.onClick.AddListener(MainMenu);
        QuitGameB.onClick.AddListener(QuitTheGame);
    }

    void ResumeGame()
    {
        pmanager.UnPauseGame();
    }

    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void QuitTheGame()
    {
        Application.Quit();
    }
}