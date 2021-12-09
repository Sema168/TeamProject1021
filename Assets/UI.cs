using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("�񕜃X�L����UI")] public GameObject heal;
    [Header("�o���A�X�L����UI")] public GameObject barrier;
    [Header("���g�X�L����UI")] public GameObject increace;

    private int count = 0;
    private int skillNum;



    void Start()
    {
        heal.SetActive(true);
        barrier.SetActive(false);
        increace.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            skillNum = count % 3;

            if (skillNum == 1)
            {
                heal.SetActive(false);
                barrier.SetActive(true);
                increace.SetActive(false);
            }
            else if (skillNum == 2)
            {
                heal.SetActive(false);
                barrier.SetActive(false);
                increace.SetActive(true);
            }
            else
            {
                heal.SetActive(true);
                barrier.SetActive(false);
                increace.SetActive(false);
            }
        }
    }
}
