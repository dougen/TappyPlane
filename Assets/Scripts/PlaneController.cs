using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{


    public float rotSpeed = 0.1f;
    public float radius = 100f;

    public Vector2 upSpeed;

    // Set start flag false default.
    [HideInInspector]
    public bool gameStarted = false;

    private float radian = 0f;
    private Rigidbody2D rigd2d;
    private Vector2 startPos;
	private GameManager gm;
    private Animator anim;

    // Use this for initialization
    private void Start()
    {
        startPos = transform.position;

        // Avoid plane fall down when the game stared.
        rigd2d = GetComponent<Rigidbody2D>();
        rigd2d.gravityScale = 0f;

		gm = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // When gameStart is true, recover the gravity.
        if (!gameStarted)
        {
            IdleMove();

            if (Input.GetMouseButtonDown(0))
            {
                gameStarted = true;
                rigd2d.gravityScale = 100f;
            }
        }

        
        // Game Over
        if (gm.gameOver)
        {
            anim.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (gameStarted && Input.GetMouseButtonDown(0))
        {
            if (!gm.gameOver)
            {
                rigd2d.velocity = upSpeed;
            }
        }
    }

    // Set plane move up and down random when game start
    private void IdleMove()
    {
        radian += rotSpeed * Time.deltaTime;
        float dy = Mathf.Cos(radian) * radius;
        transform.position = startPos + new Vector2(0f, dy);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {		
		gm.gameOver = true;
    }
}
