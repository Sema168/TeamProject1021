using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
	[Header("ゲームオーバースクリプト")]
	public GameOver gameOver;
	[SerializeField, Header("ポーズ画面")]
	private GameObject pauseUI;
	[SerializeField]private GameObject panel;
	private bool isPush = false;

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
	
	/// <summary>
	/// Restartを押す
	/// </summary>
	public void RestartButton()
    {
        if (gameOver.isGameOver)
        {
			SceneManager.LoadScene("GameSceneTsuyuki");
			Time.timeScale = 1f;
			Score.score = 0;
			gameOver.isGameOver = false;
		}
        else
        {
			isPush = true;
		}
	}

	/// <summary>
	/// Exitを押す
	/// </summary>
	public void OnClicExitButton()
	{
		SceneManager.LoadScene("TitleScene");
		Time.timeScale = 1f;
		Score.score = 0;
		gameOver.isGameOver = false;
	}
}
