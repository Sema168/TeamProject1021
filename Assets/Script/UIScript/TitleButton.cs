using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    [SerializeField, Header("ランキング")]
    private GameObject rankingUI;

    /// <summary>
    /// スタートボタンを押す
    /// </summary>
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameSceneTsuyuki");
    }

    /// <summary>
    /// ランキングボタンを押す
    /// </summary>
    public void OnClickRankingButton()
    {
        rankingUI.SetActive(!rankingUI.activeSelf);
    }

    public void OnClickStartButton2()
    {
        SceneManager.LoadScene("TitleScene3");
    }
    public void OnClickStartButton3()
    {
        SceneManager.LoadScene("TitleScene2");
    }

}
