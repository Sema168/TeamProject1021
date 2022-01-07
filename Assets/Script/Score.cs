using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("レーザースクリプト")] public Laser laser;
    [System.NonSerialized] public int score;
    public Text scoreText;

    void Update()
    {
        Text scoreText = GameObject.Find("Score").GetComponent<Text>();

        scoreText.text = score.ToString();
    }
}
