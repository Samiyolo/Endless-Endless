using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathSceneManager : MonoBehaviour
{
    public Button MainMB;
    public Button RetryB;
    public Button QuitB;

    private void Start()
    {
        MainMB.onClick.AddListener(ToMainM);
        RetryB.onClick.AddListener(ToRetry);
        QuitB.onClick.AddListener(QuitGame);
    }

    void ToMainM()
    {
        SceneManager.LoadScene(0);
    }
    void ToRetry()
    {
        SceneManager.LoadScene(1);
    }
    void QuitGame()
    {
        Application.Quit();
    }
}