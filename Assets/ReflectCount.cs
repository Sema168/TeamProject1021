using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectCount : MonoBehaviour
{
    [Header("プレイヤースクリプト")] public PlayerController player;
    [Header("鏡")] public GameObject mirror;
    [Header("凸面鏡")] public GameObject convexMirror;
    [Header("凹面鏡")] public GameObject concaveMirror;

    private int countMirror;
    private int countCvMirror;
    private int countCcMirror;

    //耐久力
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
