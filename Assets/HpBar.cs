using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    /// <summary>
    /// �ő�HP
    /// </summary>
    int maxHp = 100;

    /// <summary>
    /// ���݂�HP
    /// </summary>
    int currentHp;

    [Header("HP��Slider")] public Slider hpSlider;
    [Header("�G�l���M�[��Slider")] public Slider eneSlider;


    void Start()
    {
        //Slider�𖞃^���ɂ���B
        hpSlider.value = 1;
        //���݂�HP���ő�HP�Ɠ����ɁB
        currentHp = maxHp;
    }

    void Update()
    {
        //�E�N���b�N����������
        if (Input.GetMouseButtonDown(1) && eneSlider.value >= 0.5f)
        {
            Heal();
        }
    }

    //Collider�I�u�W�F�N�g��IsTrigger�Ƀ`�F�b�N����邱�ƁB
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy"|| collider.gameObject.tag == "Laser")
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