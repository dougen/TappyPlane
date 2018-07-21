using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickControl : MonoBehaviour 
{
	private Button btn;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () 
	{
		audioSource = GetComponent<AudioSource>();

		btn = GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

    private void OnClick()
    {
       StartCoroutine(PlayClip());
    }

	private IEnumerator PlayClip()
	{
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);
		FindObjectOfType<GameManager>().Restart();
	}

	
}
