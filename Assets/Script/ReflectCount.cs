using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectCount : MonoBehaviour
{
    [Header("プレイヤースクリプト")] public PlayerController player;
    [Header("鏡")] public GameObject mirror;
    [Header("凸面鏡")] public GameObject convexMirror;
    [Header("凹面鏡")] public GameObject concaveMirror;

    //反射した回数
    private int countMirror;
    private int countCvMirror;
    private int countCcMirror;

    //耐久力
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
