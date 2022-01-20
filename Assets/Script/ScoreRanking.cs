using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRanking : MonoBehaviour
{
    private int point;
    private string[] ranking = { "1��", "2��", "3��"};
    private int[] rankingScore = new int[3];
    [SerializeField]
    private GameObject rankingUI;
    [SerializeField, Header("�\��������e�L�X�g")]
    private Text[] rankingText = new Text[3];
    private int isOnece = 0;
    void Start()
    {
        //point = Score.score;
        //GetRanking();
        //SetRanking(point);
        //for (int i = 0; i < rankingText.Length; i++)
        //{
        //    rankingText[i].text = rankingScore[i].ToString();
        //}
    }
    void Update()
    {
        if (rankingUI.activeSelf && isOnece == 0)
        {
            isOnece++;
            point = Score.score;
            GetRanking();
            SetRanking(point);
            for (int i = 0; i < rankingText.Length; i++)
            {
                rankingText[i].text = rankingScore[i].ToString();
            }
        }
        else if (!rankingUI.activeSelf && isOnece == 1)
        {
            isOnece--;
        }
    }
    void GetRanking()
    {
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingScore[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    void SetRanking(int score)
    {
        for (int i = 0; i < ranking.Length; i++)
        {
            if (score > rankingScore[i])
            {
                var newscore = rankingScore[i];
                rankingScore[i] = score;
                score = newscore;
            }
        }
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingScore[i]);
        }
    }
    //public GameObject score_object = null; // Text�I�u�W�F�N�g
    //public int score_num = 0; // �X�R�A�ϐ�
    //public Score score;

    //// ���������̏���
    //void Start()
    //{
    //    // �X�R�A�̃��[�h
    //    score_num = PlayerPrefs.GetInt("SCORE", 0);
    //}
    //// �폜���̏���
    //void OnDestroy()
    //{
    //    // �X�R�A��ۑ�
    //    PlayerPrefs.SetInt("SCORE", score_num);
    //    PlayerPrefs.Save();
    //}

    //// �X�V
    //void Update()
    //{
    //    // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
    //    Text score_text = score_object.GetComponent<Text>();
    //    // �e�L�X�g�̕\�������ւ���
    //    score_text.text = "Score:" + score_num;

    //    score_num += 1; // �Ƃ肠����1���Z�������Ă݂�
    //}
}
