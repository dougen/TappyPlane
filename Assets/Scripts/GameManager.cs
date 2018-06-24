using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject rockPrefab;
    public PlaneController pc;
    public Text scoresText;
	
	public float swapPos;
	public float swapStep;
	public int rockNum;

    [HideInInspector]
    public bool gameOver = false;
    public int scores = 0;
    
	private bool swaped = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pc.gameStarted && !swaped)
        {
			swaped = true;
            SwapRocks();
            scoresText.gameObject.SetActive(true);
        }

        scoresText.text = scores.ToString();

        // GameOver. 
        // TODO: Stop the game and popup the sorce UI.
        if (gameOver)
        {
            scoresText.gameObject.SetActive(false);
        }
    }

    private void SwapRocks()
    {
        for (var i = 0; i < rockNum; i++)
        {
            GameObject rock = Instantiate(rockPrefab, new Vector3(swapPos + i * swapStep, 0f, 0f), Quaternion.identity);
			RocksScripts rs = rock.GetComponent<RocksScripts>();
			rs.startPos.x = swapPos;
			rs.endPos.x = swapPos - swapStep * rockNum;
        }
    }

}
