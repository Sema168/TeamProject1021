using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyBay : MonoBehaviour
{
    Slider _slider;
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    float _Energy = 0;
    void Update()
    {
        // エネルギー上昇
        _Energy += 0.01f;
        if (_Energy > 1)
        {
            // 最大を超えたら0に戻す
            _Energy = 0;
        }

        // エネルギーゲージに値を設定
        _slider.value = _Energy;
    }
}
