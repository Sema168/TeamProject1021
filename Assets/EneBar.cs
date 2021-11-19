using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneBar : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxEne = 155;
    int currentEne;

    //Sliderを入れる
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentEne = maxEne;
        Debug.Log("Start currentHp : " + currentEne);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            //ダメージは1～100の中でランダムに決める。
            int damage = 20;
            Debug.Log("damage : " + damage);

            //現在のHPからダメージを引く
            currentEne = currentEne - damage;
            Debug.Log("After currentHp : " + currentEne);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentEne / (float)maxEne; ;
            Debug.Log("slider.value : " + slider.value);

        }
    }
}