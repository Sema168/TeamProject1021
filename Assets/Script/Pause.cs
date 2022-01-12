using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

	//　ポーズした時に表示するUI
	[SerializeField]
	private GameObject pauseUI;
	[SerializeField]
	private GameObject panel;
	private bool isPush = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || isPush == true)
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
