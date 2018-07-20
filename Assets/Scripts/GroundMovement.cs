using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour 
{

	public Vector2 startPos;
	public Vector2 endPos;
	public float moveSpeed = 100f;
	public Sprite[] sprites;

	private GameManager gm;
	private SpriteRenderer sr;

	private void Start() 
	{
		gm = FindObjectOfType<GameManager>();
		sr = GetComponent<SpriteRenderer>();
	}

	private void Update() 
	{
		if (transform.position.x < endPos.x)
		{
			transform.position = startPos;
			SwitchSprites();
		}

		if (!gm.gameOver)
		{
			transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
		}
	}

	private void SwitchSprites()
	{

        if (gm.scores >= gm.levels[0] && gm.scores < gm.levels[1])
        {
        	sr.sprite = sprites[0];
        }
        else if (gm.scores >= gm.levels[1] && gm.scores < gm.levels[2])
        {
        	sr.sprite = sprites[1];
        }
        else if (gm.scores >= gm.levels[2])
        {
        	sr.sprite = sprites[2];
        }
	}

}
