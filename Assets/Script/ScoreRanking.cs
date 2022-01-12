using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRanking : MonoBehaviour
{
    int point;
    string[] ranking = { "1��", "2��", "3��", "4��", "5��" };
    int[] rankingScore = new int[5];
    [SerializeField, Header("�\��������e�L�X�g")]
    Text[] rankingText = new Text[5];
    //Text[] rankingName = new Text[5];
    void Start()
    {
        //point = score.tensu;
        GetRanking();
        SetRanking(point);
        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = rankingScore[i].ToString();
        }
    }
    void Update()
    {

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
