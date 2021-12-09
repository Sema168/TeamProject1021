using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectCount : MonoBehaviour
{
    [Header("�v���C���[�X�N���v�g")] public PlayerController player;
    [Header("��")] public GameObject mirror;
    [Header("�ʖʋ�")] public GameObject convexMirror;
    [Header("���ʋ�")] public GameObject concaveMirror;

    private int countMirror;
    private int countCvMirror;
    private int countCcMirror;

    //�ϋv��
    private int mirrorBreakNum = 10;
    private int cvMirrorBreakNum = 5;
    private int ccMirrorBreakNum = 10;



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
        if (countMirror >= mirrorBreakNum)
        {
            mirror.SetActive(false);
            player.mirrorStock--;
            countMirror = 0;
            Debug.Log("mirrorStock : "+ player.mirrorStock);
        }
        if (countCvMirror >= cvMirrorBreakNum)
        {
            convexMirror.SetActive(false);
            player.convexMirrorStock--;
            countCvMirror = 0;
            Debug.Log("convexMirrorStock : "+ player.convexMirrorStock);
        }
        if (countCcMirror >= ccMirrorBreakNum)
        {
            concaveMirror.SetActive(false);
            player.concaveMirrorStock--;
            countCcMirror = 0;
            Debug.Log("concaveMirrorStock : "+ player.concaveMirrorStock);
        }
    }
}
