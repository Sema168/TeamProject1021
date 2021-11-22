using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneBar : MonoBehaviour
{
    /// <summary>
    /// 最大エネルギー量
    /// </summary>
    int maxEne = 100;

    /// <summary>
    /// 現在のエネルギー量
    /// </summary>
    int currentEne;

    [Header("エネルギーのSlider")] public Slider eneSlider;

    void Start()
    {
        //Sliderを満タンにする。
        eneSlider.value = 1;
        //現在のエネルギーを最大エネルギーと同じに。
        currentEne = maxEne;
    }

    void Update()
    {
        //右クリックを押した時
        if (Input.GetMouseButtonDown(1))
        {
            //エネルギーの消費量
            int cost = 20;

            //現在のエネルギーから消費量を引く
            currentEne = currentEne - cost;

            //最大エネルギーにおける現在のエネルギーをSliderに反映。
            eneSlider.value = (float)currentEne / (float)maxEne;
        }
    }
}