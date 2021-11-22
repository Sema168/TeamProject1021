using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneBar : MonoBehaviour
{
    /// <summary>
    /// �ő�G�l���M�[��
    /// </summary>
    int maxEne = 100;

    /// <summary>
    /// ���݂̃G�l���M�[��
    /// </summary>
    int currentEne;

    [Header("�G�l���M�[��Slider")] public Slider eneSlider;

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
            int cost = 20;

            //���݂̃G�l���M�[�������ʂ�����
            currentEne = currentEne - cost;

            //�ő�G�l���M�[�ɂ����錻�݂̃G�l���M�[��Slider�ɔ��f�B
            eneSlider.value = (float)currentEne / (float)maxEne;
        }
    }
}