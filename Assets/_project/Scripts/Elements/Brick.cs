using System;
using DG.Tweening;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private Level _level;
    
    public int startHealth;
    private int currentHealth;
    public SpriteRenderer sprite;
    public float colorStep;
    
    public void StartBrick(Level level)
    {
        _level = level;
        currentHealth = startHealth;
        sprite.color = new Color(1,(1 - currentHealth * colorStep),(1 - currentHealth * colorStep),1);
        
    }

    public void GetHit()
    {
        currentHealth--;
        PlayVisualFX(); 
        if (currentHealth == 0)
        {
            DestroyBrick();
        }
        print(currentHealth);
    }

    private void PlayVisualFX()
    {
        sprite.transform.DOKill();
        sprite.transform.localScale = 0.2f * Vector3.one;
        sprite.transform.localPosition = Vector3.zero;
        sprite.transform.DOScale(0.25f, 0.1f).SetLoops(2, LoopType.Yoyo);
        sprite.DOColor(new Color(1, (1 - currentHealth * colorStep), (1 - currentHealth * colorStep), 1), 0.1f);
        sprite.transform.DOPunchPosition(Vector3.one * 0.1f, 0.1f, 100);
    }

    private void DestroyBrick()
    {
        gameObject.SetActive(false);
        _level.BrickDestroyed(this);
    }

    
}
