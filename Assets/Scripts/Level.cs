using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int blocksLeft;
    private int ballsLeft;
    
    private SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddBall()
    {
        ballsLeft++;
    }

    public bool IsGameOver()
    {
        return (--ballsLeft) <= 0;
    }
    
    public void AddBlock()
    {
        blocksLeft++;
    }

    public void RemoveBlock()
    {
        blocksLeft--;
        
        if (blocksLeft <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
