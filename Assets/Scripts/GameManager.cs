using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject rockPrefab;
    public PlaneController pc;
    public Text scoresText;
    public Text finalScore;
    public Text bestScore;
    public Text newRecord;
    public GameObject gameOverPanel;

    public float swapPos;
    public float swapStep;
    public int rockNum;

    public int[] levels;

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
        // Stop the game and popup the sorce UI.
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
        path = Path.Combine(path, "save.data");

        if (!File.Exists(path))
        {
            File.CreateText(path).Dispose();
        }
        else
        {
            string raw = File.ReadAllText(path);
            try
            {
                best = System.Convert.ToInt32(raw);
            }
            catch (System.FormatException)
            {
                best = 0;
            }
        }

        if (score > best)
        {
            // Be the best score, save it!
            best = score;
            newRecord.gameObject.SetActive(true);
            File.WriteAllText(path, score.ToString());
        }
        return best.ToString();
    }


    // Reload game
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
