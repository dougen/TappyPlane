﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMovement : MonoBehaviour 
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

		transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
	}
}
