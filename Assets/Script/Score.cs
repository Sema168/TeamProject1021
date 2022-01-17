using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] public static int score;
    private int maxScore = 999999;
    public Text scoreText;

    void Update()
    {
        Text scoreText = GameObject.Find("ScoreText").GetComponent<Text>();


        if (score == 0)
        {
            scoreText.text = "00000" + score;
        }
        else if (0 < score && score < 1000) 
        {
            scoreText.text = "000" + score;
        }
        else if (1000 <= score && score < 10000)
        {
            scoreText.text = "00" + score;
        }
        else if (10000 <= score && score < 100000)
        {
            scoreText.text = "0" + score;
        }
        else if (100000 <= score && score < 1000000)
        {
            scoreText.text = "" + score;
        }
        else
        {
            scoreText.text = "" + maxScore;
        }
    }
}
