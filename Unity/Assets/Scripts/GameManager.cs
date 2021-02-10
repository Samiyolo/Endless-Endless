using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ChunkSpawnLoc;
    private float Timefloat;
    private enum DifficultyState {Easy, Medium, Hard}
    private DifficultyState difficulty;
    public GameObject[] obstacleChunksE;
    public GameObject[] obstacleChunksM;
    public GameObject[] obstacleChunksH;

    private float scoreTimer;
    private float score;
    public float multiplier;
    [SerializeField] private Text scoreUI;
    [SerializeField] private Text multiplierUI;

    private void Start()
    {
        difficulty = DifficultyState.Easy;
        Time.timeScale = 1;
        multiplier = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            multiplier = multiplier * 2;
        }
        Timefloat += Time.deltaTime;
        if (Timefloat >= 20)
        {
            difficulty = DifficultyState.Medium;
        }
        if (Timefloat >= 40)
        {
            difficulty = DifficultyState.Hard;
        }

        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= 0.5f)
        {
            score = score + 10 * multiplier;
            scoreTimer = 0;
        }

        scoreUI.text = "Score: " + score.ToString("00");
        multiplierUI.text = multiplier.ToString("x0.00");
    }

    public void SpawnObject()
    {
        switch (difficulty)
        {
            case DifficultyState.Easy:
                Instantiate(obstacleChunksE[Random.Range(0, (obstacleChunksE.Length - 1))], position: ChunkSpawnLoc.transform.position, rotation: Quaternion.identity);
                break;
            case DifficultyState.Medium:
                Instantiate(obstacleChunksM[Random.Range(0, (obstacleChunksM.Length - 1))], position: ChunkSpawnLoc.transform.position, rotation: Quaternion.identity);
                break;
            case DifficultyState.Hard:
                Instantiate(obstacleChunksH[Random.Range(0, (obstacleChunksH.Length - 1))], position: ChunkSpawnLoc.transform.position, rotation: Quaternion.identity);
                break;
            default:
                Instantiate(obstacleChunksM[Random.Range(0, (obstacleChunksM.Length - 1))], position: new   Vector3(ChunkSpawnLoc.transform.position.x, ChunkSpawnLoc.transform.position.y, ChunkSpawnLoc.transform.position.z + 10), rotation: Quaternion.identity);
                break;
        }
    }

    public GameObject playerOBJ;
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}