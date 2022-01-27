using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorUI : MonoBehaviour
{
    [Header("�v���C���[�X�N���v�g")] public PlayerController player;
    [SerializeField, Header("���̏������e�L�X�g")]
    private Text mirrorUIText;
    [SerializeField, Header("�ʖʋ��̏������e�L�X�g")]
    private Text cvMirrorUIText;
    [SerializeField, Header("���ʋ��̏������e�L�X�g")]
    private Text ccMirrorUIText;
    [SerializeField, Header("���ʋ��̏������e�L�X�g")]
    private Text mirrorStockUIText;


    void Update()
    {
        Text mirrorText = mirrorUIText.GetComponent<Text>();
        Text cvMirrorText = cvMirrorUIText.GetComponent<Text>();
        Text ccMirrorText = ccMirrorUIText.GetComponent<Text>();
        Text mirrorStockText = mirrorStockUIText.GetComponent<Text>();

        mirrorText.text = "�~" + player.mirrorStock;
        cvMirrorText.text = "�~" + player.convexMirrorStock;
        ccMirrorText.text = "�~" + player.concaveMirrorStock;
        mirrorStockText.text = player.currentStock + " / 3";
    }
}
