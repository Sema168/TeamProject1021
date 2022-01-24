using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectCount : MonoBehaviour
{
    [Header("�v���C���[�X�N���v�g")] public PlayerController player;
    [Header("��")] public GameObject mirror;
    [Header("�ʖʋ�")] public GameObject convexMirror;
    [Header("���ʋ�")] public GameObject concaveMirror;

    //���˂�����
    private int countMirror;
    private int countCvMirror;
    private int countCcMirror;

    //�ϋv��
    private int mirrorBreakNum = 15;
    private int cvMirrorBreakNum = 10;
    private int ccMirrorBreakNum = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision .gameObject .tag == "Laser")
        {
            if (mirror.activeSelf)
            {
                countMirror++;
            }
            else if (convexMirror.activeSelf )
            {
                countCvMirror++;
            }
            else if (concaveMirror.activeSelf)
            {
                countCcMirror++;
            }
        }
    }

    void Update()
    {
        if (countMirror >= mirrorBreakNum)
        {
            mirror.SetActive(false);
            player.mirrorStock--;
            countMirror = 0;
        }
        if (countCvMirror >= cvMirrorBreakNum)
        {
            convexMirror.SetActive(false);
            player.convexMirrorStock--;
            countCvMirror = 0;
        }
        if (countCcMirror >= ccMirrorBreakNum)
        {
            concaveMirror.SetActive(false);
            player.concaveMirrorStock--;
            countCcMirror = 0;
        }
    }
}
