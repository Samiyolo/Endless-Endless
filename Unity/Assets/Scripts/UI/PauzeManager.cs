using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauzeManager : MonoBehaviour
{
    public GameObject PauseMenuOBJs;
    private bool IsPaused;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void CheckIfPaused()
    {
        if (!IsPaused)
        {
            PauseGame();
        }
        else
        {
            UnPauseGame();
        }
    }

    private void Update()
    {
        PauseMenuOBJs.SetActive(IsPaused);
        player.CanControl = !IsPaused;
    }

    private void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        IsPaused = false;
        Time.timeScale = 1;
    }
}