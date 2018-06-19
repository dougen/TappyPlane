using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour 
{

	
	public float rotSpeed = 0.1f;
	public float radius = 100f;

	public Vector2 upSpeed;

	// Set start flag false default.
	private bool gameStart = false;

	private float radian = 0f;
	private Rigidbody2D rigd2d;
	private Vector2 startPos;

	// Use this for initialization
	private void Start () 
	{
		startPos = transform.position;

		// Avoid plane fall down when the game stared.
		rigd2d = GetComponent<Rigidbody2D>();
		rigd2d.gravityScale = 0f;	
	}
	
	// Update is called once per frame
	private void Update () 
	{
		if (!gameStart) 
		{
			IdleMove();
		}

		// when gameStart is true, recover the gravity.
		if (!gameStart && Input.GetMouseButtonDown(0))
		{
			gameStart = true;
			rigd2d.gravityScale = 100f;
		}
	}

	private void FixedUpdate() 
	{
		if (gameStart && Input.GetMouseButtonDown(0)) {
			rigd2d.velocity = upSpeed;
		}
	}

	// Set plane move up and down random when game start
	private void IdleMove() 
	{
		radian += rotSpeed * Time.deltaTime;
		float dy = Mathf.Cos(radian) * radius;
		transform.position = startPos + new Vector2(0f, dy);
	}
}
