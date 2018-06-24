using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapAnimation : MonoBehaviour 
{
	public Sprite[] sprites;
	public float fps;

	private Image image;
	private int count = 0;
	private float timeCount = 0f;
	private PlaneController pc;


	// Use this for initialization
	void Start () 
	{
		image = GetComponent<Image>();
		pc = FindObjectOfType<PlaneController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeCount += Time.deltaTime;

		if (timeCount > 1/fps)
		{
			timeCount = 0f;
			count++;
			image.sprite = sprites[count % sprites.Length];
		}

		if (pc.gameStarted) 
		{
			transform.parent.gameObject.SetActive(false);
		}
	}
}
