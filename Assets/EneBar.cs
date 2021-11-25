using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneBar : MonoBehaviour
{
    [Header("�ő�G�l���M�[��")] public int maxEne;
    [Header("�G�l���M�[��Slider")] public Slider eneSlider;
    public HpBar hpBar;

    /// <summary>
    /// ���݂̃G�l���M�[��
    /// </summary>
    private int currentEne;
    /// <summary>
    /// �G�l���M�[�̏����
    /// </summary>
    private int cost;


    void Start()
    {
        //Slider�𖞃^���ɂ���B
        eneSlider.value = 1;
        //���݂̃G�l���M�[���ő�G�l���M�[�Ɠ����ɁB
        currentEne = maxEne;
    }

    void Update()
    {
        //�E�N���b�N����������
        if (Input.GetMouseButtonDown(1))
        {
            //�G�l���M�[�̏����
            cost = 110;

            //�G�l���M�[������ʕ��c���Ă���Ƃ�
            if (eneSlider.value >= (float)cost / (float)maxEne)
            {
                EneSliderControll();
                hpBar.Heal();
                Debug.Log("�񕜂���");
            }
        }
    }

    void EneSliderControll()
    {
        //���݂̃G�l���M�[�������ʂ�����
        currentEne = currentEne - cost;

        //�ő�G�l���M�[�ɂ����錻�݂̃G�l���M�[��Slider�ɔ��f�B
        eneSlider.value = (float)currentEne / (float)maxEne;
    }
}