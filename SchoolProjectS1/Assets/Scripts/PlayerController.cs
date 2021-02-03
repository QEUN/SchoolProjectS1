using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C# is schijt

public class PlayerController : MonoBehaviour
{
    private const float speed = 7.0f;
    private const float upperBound = 5.265f;
    private const float lowerBound = -3.27f;
    private const float leftBound = -6.081f;
    private const float rightBound = 6.081f;

    private bool leftPressed = false;
    private bool rightPressed = false;
    private bool upPressed = false;
    private bool downPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        leftPressed = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        rightPressed = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        upPressed = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        downPressed = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        // Move player
        if (leftPressed && !rightPressed)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (rightPressed && !leftPressed)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (upPressed && !downPressed)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if (downPressed && !upPressed)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        // Prevent player from exiting screen
        if (transform.position.y > upperBound)
        {
            transform.Translate(new Vector2(0.0f, upperBound - transform.position.y));
        }
        else if (transform.position.y < lowerBound)
        {
            transform.Translate(new Vector2(0.0f, lowerBound - transform.position.y));
        }
        if (transform.position.x < leftBound)
        {
            transform.Translate(new Vector2(leftBound - transform.position.x, 0.0f));
        }
        else if (transform.position.x > rightBound)
        {
            transform.Translate(new Vector2(rightBound - transform.position.x, 0.0f));
        }
    }
}