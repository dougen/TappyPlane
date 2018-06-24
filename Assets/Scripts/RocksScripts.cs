using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksScripts : MonoBehaviour 
{

	// Distance between rock and rockDown
	public float gap;
	public float moveSpeed;

	// Set the swap postion
	public Vector2 startPos;
	public Vector2 endPos;
	public Vector2 heightPos;

	public Transform rock;
	public Transform rockDown;

	private GameManager gm;
	private GameObject plane;
	private bool passed;

	

	// Use this for initialization
	void Start () 
	{
		rock.transform.position = new Vector2(transform.position.x, transform.position.y - gap / 2);
		rockDown.transform.position = new Vector2(transform.position.x, transform.position.y + gap / 2);
		transform.position = new Vector2(transform.position.x, Random.Range(heightPos.x, heightPos.y));

		gm = FindObjectOfType<GameManager>();
		plane = GameObject.Find("Plane");
		passed = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < endPos.x) 
		{
			startPos.y = Random.Range(heightPos.x, heightPos.y);
			transform.position = startPos;
			passed = false;
		}

		if (!gm.gameOver)
		{
			transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);

			if (transform.position.x < plane.transform.position.x && !passed) 
			{
				gm.scores++;
				passed = true;
			}
		}
	}
}
