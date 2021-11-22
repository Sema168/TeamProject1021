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

    [Header("HPのSlider")] public Slider slider;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
    }

    void Update()
    {
        //右クリックを押した時
        if (Input.GetMouseButtonDown(1))
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
            slider.value = (float)currentHp / (float)maxHp; ;
        }
    }

    /// <summary>
    /// 回復スキルの処理
    /// </summary>
    public void Heal()
    {
        //回復量
        int heal = 20;

        currentHp = currentHp + heal;
        //現在のHPが最大HPを超えた時、最大HPと同じにする
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        slider.value = (float)currentHp / (float)maxHp; ;
    }
}