using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public GameObject rankingUI;
    private int isOnece = 0;

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameSceneTsuyuki");
    }

    public void OnClickRankingButton()
    {
        rankingUI.SetActive(!rankingUI.activeSelf);
    }
}
