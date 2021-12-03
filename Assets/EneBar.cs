using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneBar : MonoBehaviour
{
    [Header("最大エネルギー量")] public int maxEne;
    [Header("エネルギーのSlider")] public Slider eneSlider;
    [Header("HpBarのスクリプト")] public HpBar hpBar;

    /// <summary>
    /// 現在のエネルギー量
    /// </summary>
    private int currentEne;
    /// <summary>
    /// エネルギーの消費量
    /// </summary>
    private int cost;


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
            cost = 50;

            //エネルギーが消費量分残っているとき
            if (eneSlider.value >= (float)cost / (float)maxEne)
            {
                EneSliderControll();
                //hpBar.Heal();
                //Debug.Log("回復した");
            }
        }
    }

    void EneSliderControll()
    {
        //現在のエネルギーから消費量を引く
        currentEne = currentEne - cost;

        //最大エネルギーにおける現在のエネルギーをSliderに反映。
        eneSlider.value = (float)currentEne / (float)maxEne;
    }
}