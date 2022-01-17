using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
