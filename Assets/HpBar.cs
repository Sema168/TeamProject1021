using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxHp = 155;
    int currentHp;
    //Sliderを入れる
    public Slider slider;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //回復する処理
            int heal = 20;
            currentHp = currentHp + heal;
            if (currentHp > maxHp)
            {
                currentHp = 155;
            }
            slider.value = (float)currentHp / (float)maxHp; ;
        }
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Enemyタグのオブジェクトに触れると発動
        if (collider.gameObject.tag == "Enemy"|| collider.gameObject.tag == "Laser")
        {
            //ダメージは1～100の中でランダムに決める。
            int damage = 20;
            Debug.Log("damage : " + damage);

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;
            Debug.Log("After currentHp : " + currentHp);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp; ;
            Debug.Log("slider.value : " + slider.value);
        }
    }
}