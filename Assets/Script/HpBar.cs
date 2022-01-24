using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [Header("HP��Slider")] public Slider hpSlider;
    [Header("�v���C���[�X�N���v�g")] public PlayerController player;
    [Header("�Q�[���I�[�o�[�X�N���v�g")] public GameOver gameOver;


    /// <summary>
    /// �ő�HP
    /// </summary>
    private int maxHp = 100;

    /// <summary>
    /// ���݂�HP
    /// </summary>
    private int currentHp;

    /// <summary>
    /// �_���[�W
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
    /// �񕜃X�L���̏���
    /// </summary>
    public void Heal()
    {
        //�񕜗�
        int heal = maxHp;

        currentHp = currentHp + heal;
        //���݂�HP���ő�HP�𒴂������A�ő�HP�Ɠ����ɂ���
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpSlider.value = (float)currentHp / (float)maxHp; ;
    }
}