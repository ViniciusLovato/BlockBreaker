using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private GameObject blockSparklesVFX;
    [SerializeField] private Ball ball;
    [SerializeField] private Sprite[] hitSprites;
    
    private int maxHits = 0;
    private int timesHit = 0;
    private Level level;
    private GameSession gameSession;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        maxHits = hitSprites.Length + 1;
        
        if (IsBlockBreakable())
        {
            level.AddBlock();    
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (IsBlockBreakable())
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (IsMaxDamage())
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        spriteRenderer.sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        level.RemoveBlock();
        gameSession.IncreaseScore();
        TriggerSparklesVFX();
        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject effect = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(effect, 1f);
        
    }

    private bool IsBlockBreakable()
    {
        return CompareTag("Breakable");
    }

    private bool IsMaxDamage()
    {
        return timesHit >= maxHits;
    }
}
