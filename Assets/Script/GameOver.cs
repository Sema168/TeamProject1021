using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]Å@private GameObject gameOverText;
    [SerializeField]Å@private GameObject rankingUI;
    [SerializeField]Å@private GameObject panel;
    [System.NonSerialized] public bool isGameOver = false;

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
