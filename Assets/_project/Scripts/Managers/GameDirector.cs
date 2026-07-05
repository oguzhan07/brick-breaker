using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public LevelManager levelManager;
    public BrickManager brickManager;
    public Player player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadPreviousLevel();
        }
    }

    private void LoadNextLevel()
    {
        levelManager.currentLevelNo += 1;
        RestartLevel();
        player.RestartPlayer();
    }

    private void LoadPreviousLevel()
    {
        levelManager.currentLevelNo = Mathf.Max(levelManager.currentLevelNo - 1, 1);
        RestartLevel();
        player.RestartPlayer();
    }

    void RestartLevel()
    {
        levelManager.RestartLevelManager();
        brickManager.RestartBrickManager();
        player.RestartPlayer();
    }

    public void Win()
    {
        print("You won the level");
    }
}     
