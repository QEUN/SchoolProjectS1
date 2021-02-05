using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CCCCCC    ##  ##                  SSSSSS  CCCCCC  HH  HH  II    JJ  TTTTTT
// CC      ##########    ========    SS      CC      HH  HH  II    JJ    TT
// CC        ##  ##                  SSSSSS  CC      HHHHHH  II    JJ    TT
// CC      ##########    ========        SS  CC      HH  HH  II    JJ    TT
// CCCCCC    ##  ##                  SSSSSS  CCCCCC  HH  HH  II  JJJJ    TT

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;
    private const float acceleration = 50.0f;
    private const float deceleration = 15.0f;
    private Vector2 motion;
    private const float upperBound = 5.265f;
    private const float lowerBound = -3.27f;
    private const float leftBound = -8.307f;
    private const float rightBound = 8.307f;

    private bool leftPressed = false;
    private bool rightPressed = false;
    private bool upPressed = false;
    private bool downPressed = false;

    public GameObject spawnManager;
    private SpawnManager spawnManangerScript;

    public GameObject timer;
    private TextMesh timerMesh;

    public GameObject score;
    private TextMesh scoreMesh;
    public GameObject gameOverText;
    private TextMesh gameOverTextMesh;

    private SpriteRenderer spriteRenderer;

    private const float startTime = 10.0f;
    private float remainingTime = startTime;

    private int scoreVal = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnManangerScript = spawnManager.GetComponent<SpawnManager>();
        timerMesh = timer.GetComponent<TextMesh>();
        scoreMesh = score.GetComponent<TextMesh>();
        gameOverTextMesh = gameOverText.GetComponent<TextMesh>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
                motion.x -= acceleration * Time.deltaTime;
                spriteRenderer.flipX = false;
            }
            else if (rightPressed && !leftPressed)
            {
                motion.x += acceleration * Time.deltaTime;
                spriteRenderer.flipX = true;
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
                motion.y += acceleration * Time.deltaTime;
                spriteRenderer.flipY = false;
            }
            else if (downPressed && !upPressed)
            {
                motion.y -= acceleration * Time.deltaTime;
                spriteRenderer.flipY = true;
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

            // Move player
            transform.Translate(motion * Time.deltaTime);

            // Game over if the player exits the screen
            if (transform.position.y > upperBound)
            {
                transform.Translate(new Vector2(0.0f, upperBound - transform.position.y));
                motion.y = 0.0f;
                gameOver = true;
                gameOverTextMesh.text = "GAME OVER!\nPress R to retry";
            }
            else if (transform.position.y < lowerBound)
            {
                transform.Translate(new Vector2(0.0f, lowerBound - transform.position.y));
                motion.y = 0.0f;
                gameOver = true;
                gameOverTextMesh.text = "GAME OVER!\nPress R to retry";
            }
            if (transform.position.x < leftBound)
            {
                transform.Translate(new Vector2(leftBound - transform.position.x, 0.0f));
                motion.x = 0.0f;
                gameOver = true;
                gameOverTextMesh.text = "GAME OVER!\nPress R to retry";
            }
            else if (transform.position.x > rightBound)
            {
                transform.Translate(new Vector2(rightBound - transform.position.x, 0.0f));
                motion.x = 0.0f;
                gameOver = true;
                gameOverTextMesh.text = "GAME OVER!\nPress R to retry";
            }

            // Decrement time
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else
            {
                // Gameover if time reaches zero
                gameOver = true;
                gameOverTextMesh.text = "GAME OVER!\nPress R to retry";
            }
            timerMesh.text = "" + (int)Mathf.Ceil(remainingTime);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset everything
            gameOver = false;
            transform.position = new Vector3(0.0f, 1.0f, -5.0f);
            motion = new Vector2(0.0f, 0.0f);
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
            Destroy(GameObject.Find("SpawnBullshit(Clone)"));
            spawnManangerScript.SpawnRandomLocation();
            remainingTime = startTime;
            scoreVal = 0;
            scoreMesh.text = "Score: " + scoreVal;
            gameOverTextMesh.text = "";
        }
    }

    void OnCollisionEnter(Collision col)
    {
        // Weet ik veel
        remainingTime += 0.5f;
        scoreVal++;
        scoreMesh.text = "Score: " + scoreVal;
        Destroy(col.gameObject);
        spawnManangerScript.SpawnRandomLocation();
    }
}