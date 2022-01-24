using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    [SerializeField, Header("�����L���O")]
    private GameObject rankingUI;

    /// <summary>
    /// �X�^�[�g�{�^��������
    /// </summary>
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameSceneTsuyuki");
    }

    /// <summary>
    /// �����L���O�{�^��������
    /// </summary>
    public void OnClickRankingButton()
    {
        rankingUI.SetActive(!rankingUI.activeSelf);
    }
}
