using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRanking : MonoBehaviour
{
    private int point;
    private string[] ranking = { "1位", "2位", "3位"};
    private int[] rankingScore = new int[3];
    [SerializeField]
    private GameObject rankingUI;
    [SerializeField, Header("表示させるテキスト")]
    private Text[] rankingText = new Text[3];
    private int isOnce = 0;

    void Update()
    {
        if (rankingUI.activeSelf && isOnce == 0)
        {
            isOnce++;
            point = Score.score;
            GetRanking();
            SetRanking(point);
            for (int i = 0; i < rankingText.Length; i++)
            {
                rankingText[i].text = rankingScore[i].ToString();
            }
        }
        else if (!rankingUI.activeSelf && isOnce == 1)
        {
            isOnce--;
        }
    }
    void GetRanking()
    {
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingScore[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    void SetRanking(int score)
    {
        for (int i = 0; i < ranking.Length; i++)
        {
            if (score > rankingScore[i])
            {
                var newscore = rankingScore[i];
                rankingScore[i] = score;
                score = newscore;
            }
        }
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingScore[i]);
        }
    }
}
