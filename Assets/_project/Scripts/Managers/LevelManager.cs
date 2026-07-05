using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class LevelManager : MonoBehaviour
{
    public int currentLevelNo;
    public GameDirector gameDirector;
    private Level currentLevel;
    public List<Level> levels;
    private Ball currentBall;
    public Ball ballPrefab;
    private Player player;
    
    public void RestartLevelManager()
    {
        DeletePreviousLevel();
        CreateNewLevel();
        DeletePreviousBall();
        CreateNewBall();
    }

    private void CreateNewBall()
    {
        currentBall = Instantiate(ballPrefab);
        currentBall.transform.position = new Vector3(0, -3f, 0);
        currentBall.StartBall(new Vector3(Random.Range(-1f, 1f), 1, 0));
    }

    private void DeletePreviousBall()
    {
        if (currentBall != null)
        {
            Destroy(currentBall.gameObject);
        }
    }

    private void CreateNewLevel()
    {
        var normalizedLevelNo = (currentLevelNo - 1) % levels.Count;
        currentLevel = Instantiate(levels[normalizedLevelNo]);
        currentLevel.transform.position = Vector3.zero;
        currentLevel.StartLevel(this);
    }

    private void DeletePreviousLevel()
    {
        if (currentLevel != null) 
        {
            Destroy(currentLevel.gameObject);
        }
    }

    public void LevelCleard()
    {
        
    }
}
