using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour 
{

	public Vector2 startPos;
	public Vector2 endPos;
	public float moveSpeed = 100f;

	private void Update() 
	{
		if (transform.position.x < endPos.x)
		{
			transform.position = startPos;
		}
	}

	private void FixedUpdate() 
	{
		GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y));
	}


}
