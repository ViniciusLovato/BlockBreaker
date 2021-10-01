using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle;

    private bool hasGameStarted;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
            body.bodyType = RigidbodyType2D.Dynamic;
            body.velocity = new Vector2(Random.Range(0f, 3f), 20f);    
        }
    }

    private void LockToPaddle()
    {
        var paddleXPosition = paddle.transform.position.x;
        transform.position = new Vector2(paddleXPosition, transform.position.y);
    }
}
