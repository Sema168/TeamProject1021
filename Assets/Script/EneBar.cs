using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneBar : MonoBehaviour
{
    [Header("�G�l���M�[��Slider")] public Slider eneSlider;
    [Header("HpBar�̃X�N���v�g")] public HpBar hpBar;
    [Header("Barrier�̃X�N���v�g")] public Barrier barrier;
    [Header("Increace�̃X�N���v�g")] public Increace increace;

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
    private float[] cost= { 50, 30, 40 };//{��,�o���A,���g}
    /// <summary>
    /// �G�l���M�[�̉񕜗�
    /// </summary>
    private float eneHeal= 5.0f;


    private int count = 0;
    private int skillNum;


    void Start()
    {
        eneSlider.value = 1;
        currentEne = maxEne;
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            count++;
            skillNum = count % 3;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (skillNum == 1)
            {
                //�G�l���M�[������ʕ��c���Ă���Ƃ�
                if (eneSlider.value >= cost[skillNum ] / maxEne)
                {
                    if (!barrier.barrier.activeSelf)
                    {
                        EneSliderControll();
                        barrier.BarrierSkill();
                    }
                }
            }
            else if (skillNum == 2)
            {
                if (eneSlider.value >= cost[skillNum] / maxEne)
                {
                    EneSliderControll();
                    increace.DecoyInstance();
                }
            }
            else
            {
                //HP�����^���łȂ���
                if (hpBar.hpSlider.value != 1)
                {
                    if (eneSlider.value >= cost[skillNum] / maxEne)
                    {
                        EneSliderControll();
                        hpBar.Heal();
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
        currentEne = currentEne - cost[skillNum];

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