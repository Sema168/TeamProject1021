using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRanking : MonoBehaviour
{
    private int point;
    private string[] ranking = { "1位", "2位", "3位"};
    private int[] rankingScore = new int[3];
    [SerializeField]
    private GameObject rankingUI;
    [SerializeField, Header("表示させるテキスト")]
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
    //public GameObject score_object = null; // Textオブジェクト
    //public int score_num = 0; // スコア変数
    //public Score score;

    //// 初期化時の処理
    //void Start()
    //{
    //    // スコアのロード
    //    score_num = PlayerPrefs.GetInt("SCORE", 0);
    //}
    //// 削除時の処理
    //void OnDestroy()
    //{
    //    // スコアを保存
    //    PlayerPrefs.SetInt("SCORE", score_num);
    //    PlayerPrefs.Save();
    //}

    //// 更新
    //void Update()
    //{
    //    // オブジェクトからTextコンポーネントを取得
    //    Text score_text = score_object.GetComponent<Text>();
    //    // テキストの表示を入れ替える
    //    score_text.text = "Score:" + score_num;

    //    score_num += 1; // とりあえず1加算し続けてみる
    //}
}
