using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverText;
    [SerializeField]
    private GameObject rankingUI;
    [SerializeField]
    private GameObject panel;
    public bool isGameOver = false;

    void Start()
    {
        gameOverText.SetActive(false);
        rankingUI.SetActive(false);
        panel.SetActive(false);
    }
    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameOverText.SetActive(false);
                rankingUI.SetActive(true);
            }
        }
    }

    public void GOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverText.SetActive(true);
        panel.SetActive(true);
    }
}
