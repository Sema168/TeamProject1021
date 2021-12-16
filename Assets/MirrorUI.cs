using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorUI : MonoBehaviour
{
    [Header("プレイヤースクリプト")] public PlayerController player;
    public Text mirrorUIText;
    public Text cvMirrorUIText;
    public Text ccMirrorUIText;


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
