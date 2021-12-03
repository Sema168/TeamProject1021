using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    /// <summary>
    /// 最大HP
    /// </summary>
    int maxHp = 100;

    /// <summary>
    /// 現在のHP
    /// </summary>
    int currentHp;

    [Header("HPのSlider")] public Slider hpSlider;
    [Header("エネルギーのSlider")] public Slider eneSlider;


    void Start()
    {
        //Sliderを満タンにする。
        hpSlider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
    }

    void Update()
    {
        //右クリックを押した時
        if (Input.GetMouseButtonDown(1) && eneSlider.value >= 0.5f)
        {
            Heal();
        }
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy"|| collider.gameObject.tag == "Laser")
        {
            //ダメージ数
            int damage = 20;

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;

            //最大HPにおける現在のHPをSliderに反映。
            hpSlider.value = (float)currentHp / (float)maxHp; ;
        }
    }

    /// <summary>
    /// 回復スキルの処理
    /// </summary>
    public void Heal()
    {
        //回復量
        int heal = maxHp;

        currentHp = currentHp + heal;
        //現在のHPが最大HPを超えた時、最大HPと同じにする
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpSlider.value = (float)currentHp / (float)maxHp; ;
    }
}