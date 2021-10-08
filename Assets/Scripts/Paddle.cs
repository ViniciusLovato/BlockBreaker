using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float minimumXClamp = 1f; 
    [SerializeField] private float maximumXClamp = 15f;

    private GameSession gameSession;
    private Ball ball;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(GetPosX(), transform.position.y);
    }

    private float GetPosX()
    {
        if (gameSession.IsAutoTesting())
        {
            return ball.transform.position.x;
        }
        else
        {
            float newXPosition = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
            return Mathf.Clamp(newXPosition, minimumXClamp, maximumXClamp);    
        }
    }
    
}
