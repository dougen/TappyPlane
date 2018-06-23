using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour 
{

	public Vector2 startPos;
	public Vector2 endPos;
	public float moveSpeed = 100f;

	private GameManager gm;

	private void Start() 
	{
		gm = FindObjectOfType<GameManager>();
	}

	private void Update() 
	{
		if (transform.position.x < endPos.x)
		{
			transform.position = startPos;
		}

		if (!gm.gameOver)
		{
			transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
		}
	}

}
