using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneBar : MonoBehaviour
{
    [Header("エネルギーのSlider")] public Slider eneSlider;
    [Header("HpBarのスクリプト")] public HpBar hpBar;
    [Header("Barrierのスクリプト")] public Barrier barrier;
    [Header("Increaceのスクリプト")] public Increace increace;

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
    private float[] cost= { 50, 30, 40 };//{回復,バリア,分身}
    /// <summary>
    /// エネルギーの回復量
    /// </summary>
    private float eneHeal= 5.0f;


    private int count = 0;
    private int skillNum;


    void Start()
    {
        eneSlider.value = 1;
        currentEne = maxEne;
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            count++;
            skillNum = count % 3;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (skillNum == 1)
            {
                //エネルギーが消費量分残っているとき
                if (eneSlider.value >= cost[skillNum ] / maxEne)
                {
                    if (!barrier.barrier.activeSelf)
                    {
                        EneSliderControll();
                        barrier.BarrierSkill();
                    }
                }
            }
            else if (skillNum == 2)
            {
                if (eneSlider.value >= cost[skillNum] / maxEne)
                {
                    EneSliderControll();
                    increace.DecoyInstance();
                }
            }
            else
            {
                //HPが満タンでない時
                if (hpBar.hpSlider.value != 1)
                {
                    if (eneSlider.value >= cost[skillNum] / maxEne)
                    {
                        EneSliderControll();
                        hpBar.Heal();
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
        currentEne = currentEne - cost[skillNum];

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