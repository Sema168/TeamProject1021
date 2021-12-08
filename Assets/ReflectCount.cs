using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectCount : MonoBehaviour
{
    [Header("プレイヤースクリプト")] public PlayerController player;
    [Header("鏡のプレファブ")] public GameObject mirror;
    [Header("凸面鏡のプレファブ")] public GameObject convexMirror;
    [Header("凹面鏡のプレファブ")] public GameObject concaveMirror;

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
