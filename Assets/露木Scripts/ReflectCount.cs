using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectCount : MonoBehaviour
{
    [Header("�v���C���[�X�N���v�g")] public PlayerController player;
    [Header("���̃v���t�@�u")] public GameObject mirror;
    [Header("�ʖʋ��̃v���t�@�u")] public GameObject convexMirror;
    [Header("���ʋ��̃v���t�@�u")] public GameObject concaveMirror;

    private int countMirror;
    private int countCvMirror;
    private int countCcMirror;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision .gameObject .tag == "Laser")
        {
            if (mirror.activeSelf == true)
            {
                countMirror++;
            }
            else if (convexMirror.activeSelf == true)
            {
                countCvMirror++;
            }
            else if (concaveMirror.activeSelf == true)
            {
                countCcMirror++;
            }
        }
    }

    void Update()
    {
        if (countMirror >= 10)
        {
            mirror.SetActive(false);
            player.mirrorStock -= 1;
            countMirror = 0;
        }
        if (countCvMirror >= 10)
        {
            convexMirror.SetActive(false);
            player.convexMirrorStock -= 1;
            countCvMirror = 0;
        }
        if (countCcMirror >= 10)
        {
            concaveMirror.SetActive(false);
            player.concaveMirrorStock -= 1;
            countCcMirror = 0;
        }
    }
}
