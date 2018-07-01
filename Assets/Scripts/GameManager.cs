using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject rockPrefab;
    public PlaneController pc;
    public Text scoresText;
    public Text finalScore;
    public Text bestScore;
    public GameObject gameOverPanel;
	
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
        // Todo: Stop the game and popup the sorce UI.
        // Todo: GameOver panel need same animation when it active;
        if (gameOver)
        {
            scoresText.gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
            finalScore.text = scores.ToString();
            bestScore.text = SaveData(scores);
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

    // Save score if it's best score
    // And return the best score.
    private string SaveData(int score)
    {
        int best = 0;
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        
        // Todo: load data file, and write data

        if (score > best)
        {

            return score.ToString();
        }
        else
        {
            return best.ToString();
        }
    }
}
