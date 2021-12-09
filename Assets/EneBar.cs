using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneBar : MonoBehaviour
{
    [Header("�G�l���M�[��Slider")] public Slider eneSlider;
    [Header("HpBar�̃X�N���v�g")] public HpBar hpBar;
    [Header("Barrier�̃X�N���v�g")] public Barrier barrier;

    /// <summary>
    /// �ő�G�l���M�[��
    /// </summary>
    private float maxEne = 100.0f;
    /// <summary>
    /// ���݂̃G�l���M�[��
    /// </summary>
    private float  currentEne;
    /// <summary>
    /// �G�l���M�[�̏����
    /// </summary>
    private float  cost;
    /// <summary>
    /// �G�l���M�[�̉񕜗�
    /// </summary>
    private float eneHeal= 5.0f;

    int count = 0;
    int skillNum;


    void Start()
    {
        //Slider�𖞃^���ɂ���B
        eneSlider.value = 1;
        //���݂̃G�l���M�[���ő�G�l���M�[�Ɠ����ɁB
        currentEne = maxEne;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            skillNum = count % 3;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (skillNum == 1)
            {
                cost = 30.0f;

                //�G�l���M�[������ʕ��c���Ă���Ƃ�
                if (eneSlider.value >= cost / maxEne)
                {
                    EneSliderControll();
                    barrier.BarrierSkill();
                    Debug.Log("�o���A�����I");
                }
            }
            else if (skillNum == 2)
            {
                cost = 40.0f;

                if (eneSlider.value >= cost / maxEne)
                {
                    EneSliderControll();
                    Debug.Log("���g�����I");
                }
            }
            else
            {
                cost = 50.0f;

                //HP�����^���łȂ���
                if (hpBar.hpSlider.value != 1)
                {
                    if (eneSlider.value >= cost / maxEne)
                    {
                        EneSliderControll();
                        hpBar.Heal();
                        Debug.Log("�񕜔����I");
                    }
                }
            }
        }
    }

    /// <summary>
    /// �G�l���M�[������ʕ����炷
    /// </summary>
    void EneSliderControll()
    {
        //���݂̃G�l���M�[�������ʂ�����
        currentEne = currentEne - cost;

        //�ő�G�l���M�[�ɂ����錻�݂̃G�l���M�[��Slider�ɔ��f�B
        eneSlider.value = currentEne / maxEne;
    }

    /// <summary>
    /// �G�l���M�[���񕜂���
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