using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Brick> bricks;
    private LevelManager _levelManager;

    public void StartLevel(LevelManager levelManager)
    {
        _levelManager = levelManager;
        bricks = GetComponentsInChildren<Brick>().ToList();
        foreach (var brick in bricks)
        {
            brick.StartBrick(this);
        }
    }

    public void BrickDestroyed(Brick brick)
    {
        bricks.Remove(brick);
        if (bricks.Count == 0)
        {
            _levelManager.LevelCleard();
        }
    }
}
