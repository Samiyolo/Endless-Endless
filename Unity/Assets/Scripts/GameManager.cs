using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Start()
    {
        difficulty = DifficultyState.Easy;
        Time.timeScale = 1;
    }

    private void Update()
    {
        Timefloat += Time.deltaTime;
        if (Timefloat >= 20)
        {
            difficulty = DifficultyState.Medium;
        }
        if (Timefloat >= 40)
        {
            difficulty = DifficultyState.Hard;
        }
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