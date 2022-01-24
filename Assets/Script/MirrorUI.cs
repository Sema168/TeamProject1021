using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorUI : MonoBehaviour
{
    [Header("プレイヤースクリプト")] public PlayerController player;
    [SerializeField, Header("鏡の所持数テキスト")]
    private Text mirrorUIText;
    [SerializeField, Header("凸面鏡の所持数テキスト")]
    private Text cvMirrorUIText;
    [SerializeField, Header("凹面鏡の所持数テキスト")]
    private Text ccMirrorUIText;


    void Update()
    {
        Text mirrorText = mirrorUIText.GetComponent<Text>();
        Text cvMirrorText = cvMirrorUIText.GetComponent<Text>();
        Text ccMirrorText = ccMirrorUIText.GetComponent<Text>();

        mirrorText.text = "×" + player.mirrorStock;
        cvMirrorText.text = "×" + player.convexMirrorStock;
        ccMirrorText.text = "×" + player.concaveMirrorStock;
    }
}
