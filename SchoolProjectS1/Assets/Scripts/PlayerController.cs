using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C# is schijt

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;
    private const float acceleration = 0.1f;
    private const float deceleration = 0.03f;
    private Vector2 motion;
    private const float upperBound = 5.265f;
    private const float lowerBound = -3.27f;
    private const float leftBound = -8.307f;
    private const float rightBound = 8.307f;

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
        if (gameOver == false)
        {
            // Get input
            leftPressed = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
            rightPressed = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
            upPressed = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
            downPressed = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

            // Move player
            if (leftPressed && !rightPressed)
            {
                //transform.Translate(Vector2.left * speed * Time.deltaTime);
                motion.x -= acceleration * Time.deltaTime;
                transform.localScale = new Vector3(1.0f, transform.localScale.y, transform.localScale.z);
            }
            else if (rightPressed && !leftPressed)
            {
                //transform.Translate(Vector2.right * speed * Time.deltaTime);
                motion.x += acceleration * Time.deltaTime;
                transform.localScale = new Vector3(-1.0f, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                if (motion.x > 0.0f)
                {
                    motion.x = Mathf.Max(motion.x - deceleration * Time.deltaTime, 0.0f);
                }
                else
                {
                    motion.x = Mathf.Min(motion.x + deceleration * Time.deltaTime, 0.0f);
                }
            }

            if (upPressed && !downPressed)
            {
                //transform.Translate(Vector2.up * speed * Time.deltaTime);
                motion.y += acceleration * Time.deltaTime;
                transform.localScale = new Vector3(transform.localScale.x, 1.0f, transform.localScale.z);
            }
            else if (downPressed && !upPressed)
            {
                motion.y -= acceleration * Time.deltaTime;
                //transform.Translate(Vector2.down * speed * Time.deltaTime);
                transform.localScale = new Vector3(transform.localScale.x, -1.0f, transform.localScale.z);
            }
            else
            {
                if (motion.y > 0.0f)
                {
                    motion.y = Mathf.Max(motion.y - deceleration * Time.deltaTime, 0.0f);
                }
                else
                {
                    motion.y = Mathf.Min(motion.y + deceleration * Time.deltaTime, 0.0f);
                }
            }

            transform.Translate(motion);

            // Game over if the player exits the screen
            if (transform.position.y > upperBound)
            {
                transform.Translate(new Vector2(0.0f, upperBound - transform.position.y));
                motion.y = 0.0f;
                gameOver = true;
            }
            else if (transform.position.y < lowerBound)
            {
                transform.Translate(new Vector2(0.0f, lowerBound - transform.position.y));
                motion.y = 0.0f;
                gameOver = true;
            }
            if (transform.position.x < leftBound)
            {
                transform.Translate(new Vector2(leftBound - transform.position.x, 0.0f));
                motion.x = 0.0f;
                gameOver = true;
            }
            else if (transform.position.x > rightBound)
            {
                transform.Translate(new Vector2(rightBound - transform.position.x, 0.0f));
                motion.x = 0.0f;
                gameOver = true;
            }
        }
        else if (Input.GetKey(KeyCode.R))
        {
            gameOver = false;
            transform.position = new Vector2(0.0f, 0.0f);
            motion = new Vector2(0.0f, 0.0f);
            transform.localScale = new Vector3(1.0f, 1.0f, transform.localScale.z);
        }
    }
}