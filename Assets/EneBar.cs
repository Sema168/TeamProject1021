using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneBar : MonoBehaviour
{
    [Header("最大エネルギー量")] public float maxEne;
    [Header("エネルギーのSlider")] public Slider eneSlider;
    [Header("HpBarのスクリプト")] public HpBar hpBar;

    /// <summary>
    /// 現在のエネルギー量
    /// </summary>
    private float  currentEne;
    /// <summary>
    /// エネルギーの消費量
    /// </summary>
    private float  cost;
    /// <summary>
    /// エネルギーの回復量
    /// </summary>
    private float eneHeal= 5.0f;


    void Start()
    {
        //Sliderを満タンにする。
        eneSlider.value = 1;
        //現在のエネルギーを最大エネルギーと同じに。
        currentEne = maxEne;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //エネルギーの消費量
            cost = 50;

            //HPが満タンでない時
            if (hpBar.hpSlider.value != 1)
            {
                //エネルギーが消費量分残っているとき
                if (eneSlider.value >= cost / maxEne)
                {
                    EneSliderControll();
                    hpBar.Heal();
                }
            }
        }
    }

    /// <summary>
    /// エネルギーを消費量分減らす
    /// </summary>
    void EneSliderControll()
    {
        //現在のエネルギーから消費量を引く
        currentEne = currentEne - cost;

        //最大エネルギーにおける現在のエネルギーをSliderに反映。
        eneSlider.value = currentEne / maxEne;
    }

    public void EneHeal()
    {
        currentEne = currentEne + eneHeal;
        eneSlider.value = currentEne / maxEne;
    }
}