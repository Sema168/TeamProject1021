using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
	[SerializeField]
	private GameObject pauseUI;
	[SerializeField]
	private GameObject panel;
	private bool isPush = false;
	public GameOver gameOver;

    void Start()
    {
		pauseUI.SetActive(false);
		panel.SetActive(false);
    }

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && gameOver.isGameOver == false || isPush == true && gameOver.isGameOver == false)
		{
			pauseUI.SetActive(!pauseUI.activeSelf);
			panel.SetActive(!panel.activeSelf);
			isPush = false;

			if (pauseUI.activeSelf)
			{
				Time.timeScale = 0f;
			}
			else
			{
				Time.timeScale = 1f;
			}
		}
	}

	public void PushButton()
	{
		isPush = true;
    }

	public void RestartButton()
    {
		SceneManager.LoadScene("GameSceneTsuyuki");
		Time.timeScale = 1f;
		Score.score = 0;
		gameOver.isGameOver = false;
	}

	public void OnClicExitButton()
	{
		SceneManager.LoadScene("TitleScene");
		Time.timeScale = 1f;
		Score.score = 0;
		gameOver.isGameOver = false;
	}

}
