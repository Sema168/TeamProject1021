using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverText;
    public bool isGameOver = false;

    void Start()
    {
        gameOverText.SetActive(false);
    }

    public void GOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverText.SetActive(true);
    }
}
