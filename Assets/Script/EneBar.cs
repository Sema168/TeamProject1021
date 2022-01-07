using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneBar : MonoBehaviour
{
    [Header("エネルギーのSlider")] public Slider eneSlider;
    [Header("HpBarのスクリプト")] public HpBar hpBar;
    [Header("Barrierのスクリプト")] public Barrier barrier;

    /// <summary>
    /// 最大エネルギー量
    /// </summary>
    private float maxEne = 100.0f;
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

    int count = 0;
    int skillNum;


    void Start()
    {
        //Sliderを満タンにする。
        eneSlider.value = 1;
        //現在のエネルギーを最大エネルギーと同じに。
        currentEne = maxEne;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            skillNum = count % 3;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (skillNum == 1)
            {
                cost = 30.0f;

                //エネルギーが消費量分残っているとき
                if (eneSlider.value >= cost / maxEne)
                {
                    EneSliderControll();
                    barrier.BarrierSkill();
                    Debug.Log("バリア発動！");
                }
            }
            else if (skillNum == 2)
            {
                cost = 40.0f;

                if (eneSlider.value >= cost / maxEne)
                {
                    EneSliderControll();
                    Debug.Log("分身発動！");
                }
            }
            else
            {
                cost = 50.0f;

                //HPが満タンでない時
                if (hpBar.hpSlider.value != 1)
                {
                    if (eneSlider.value >= cost / maxEne)
                    {
                        EneSliderControll();
                        hpBar.Heal();
                        Debug.Log("回復発動！");
                    }
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

    /// <summary>
    /// エネルギーを回復する
    /// </summary>
    public void EneHeal()
    {
        currentEne = currentEne + eneHeal;
        eneSlider.value = currentEne / maxEne;

        if (currentEne > maxEne)
        {
            currentEne = maxEne;
        }
    }
}