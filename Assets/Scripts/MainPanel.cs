using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour 
{

	private Singleton sin;
	private GameManager gm;

	// Use this for initialization
	void Start () 
	{
		sin = FindObjectOfType<Singleton>();
		gm = FindObjectOfType<GameManager>();
		if (sin.playeMore)
		{
			gm.ReadyGame();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
