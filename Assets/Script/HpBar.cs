using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [Header("HPのSlider")] public Slider hpSlider;
    [Header("プレイヤースクリプト")] public PlayerController player;
    [Header("ゲームオーバースクリプト")] public GameOver gameOver;


    /// <summary>
    /// 最大HP
    /// </summary>
    private int maxHp = 100;

    /// <summary>
    /// 現在のHP
    /// </summary>
    private int currentHp;

    /// <summary>
    /// ダメージ
    /// </summary>
    private int damage = 20;


    void Start()
    {
        hpSlider.value = 1;
        currentHp = maxHp;
    }
    void Update()
    {
        if (hpSlider.value <= 0)
        {
            gameOver.GOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Laser")
        {
            currentHp = currentHp - damage;
            hpSlider.value = (float)currentHp / (float)maxHp;
            player.isDamage = true;
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