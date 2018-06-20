using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject rockPrefab;
    public PlaneController pc;
	
	public float swapPos;
	public float swapStep;
	public int rockNum;

    private int scores = 0;
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
