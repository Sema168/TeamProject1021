using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    void Update()
    {
        Text scoreUIText = scoreText.GetComponent<Text>();

        scoreUIText.text = "" + score;
    }
}
