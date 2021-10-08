using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 2f)][SerializeField] private float gameSpeed = 1f;

    [SerializeField] private int pointsPerBlockDestroyed = 83;
    
    [SerializeField] private int currentScore = 0;

    [SerializeField] private bool isAutoTesting;
    
    private TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        textMeshProUGUI = FindObjectOfType<TextMeshProUGUI>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void IncreaseScore()
    {
        currentScore += pointsPerBlockDestroyed;
        UpdateUI();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void UpdateUI()
    {
        textMeshProUGUI.text = currentScore.ToString();
    }

    public bool IsAutoTesting()
    {
        return isAutoTesting;
    }
}
