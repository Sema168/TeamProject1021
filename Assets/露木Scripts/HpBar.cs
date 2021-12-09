using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [Header("HP��Slider")] public Slider hpSlider;

    /// <summary>
    /// �ő�HP
    /// </summary>
    private int maxHp = 100;
    /// <summary>
    /// ���݂�HP
    /// </summary>
    private int currentHp;


    void Start()
    {
        //Slider�𖞃^���ɂ���B
        hpSlider.value = 1;
        //���݂�HP���ő�HP�Ɠ����ɁB
        currentHp = maxHp;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Laser")
        {
            //�_���[�W��
            int damage = 20;

            //���݂�HP����_���[�W������
            currentHp = currentHp - damage;

            //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
            hpSlider.value = (float)currentHp / (float)maxHp; ;
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