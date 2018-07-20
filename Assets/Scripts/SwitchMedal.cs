using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMedal : MonoBehaviour
{
    public Sprite[] medals;

    private Image img;

    private void Start()
    {
        img = GetComponent<Image>();

        GameManager gm = FindObjectOfType<GameManager>();
		// 控制奖牌显示的类型
        if (gm.scores >= 0 && gm.scores < gm.levels[0])
        {
            img.gameObject.SetActive(false);
        }
        else if (gm.scores >= gm.levels[0] && gm.scores < gm.levels[1])
        {
            img.sprite = medals[0];
        }
        else if (gm.scores >= gm.levels[1] && gm.scores < gm.levels[2])
        {
            img.sprite = medals[1];
        }
        else if (gm.scores >= gm.levels[2])
        {
            img.sprite = medals[2];
        }
    }
}
