using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle;
    [SerializeField] private float launchSpeed;
    [SerializeField] private AudioClip[] ballSounds;

    private Level level;
    private bool hasGameStarted;
    private Rigidbody2D body;
    private AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        
        level.AddBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGameStarted)
        {
            LockToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            hasGameStarted = true;
            body.velocity = new Vector2(Random.Range(0f, 3f), launchSpeed);    
        }
    }

    private void LockToPaddle()
    {
        var paddleXPosition = paddle.transform.position.x;
        transform.position = new Vector2(paddleXPosition, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (hasGameStarted)
        {
            this.CheckCollisionAngle(other);
            
            audioSource.PlayOneShot(ballSounds[Random.Range(0, ballSounds.Length)]);
        }
    }
    
    private void CheckCollisionAngle(Collision2D other)
    {
        Vector2 surface = other.GetContact(0).normal;
        Vector2 ballVelocity = body.velocity;

        float collisionAngle = Vector2.Angle(ballVelocity, surface);

        if (collisionAngle < 5 && other.gameObject.CompareTag("Wall Collider"))
        {
            body.velocity = new Vector2(ballVelocity.x, ballVelocity.y + Random.Range(-4f, 4f));
        }
    }
}
