using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneBar : MonoBehaviour
{
    //�ő�HP�ƌ��݂�HP�B
    int maxEne = 155;
    int currentEne;

    //Slider������
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        //Slider�𖞃^���ɂ���B
        slider.value = 1;
        //���݂�HP���ő�HP�Ɠ����ɁB
        currentEne = maxEne;
        Debug.Log("Start currentHp : " + currentEne);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            //�_���[�W��1�`100�̒��Ń����_���Ɍ��߂�B
            int damage = 20;
            Debug.Log("damage : " + damage);

            //���݂�HP����_���[�W������
            currentEne = currentEne - damage;
            Debug.Log("After currentHp : " + currentEne);

            //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
            //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂ŁA
            //(float)������float�̕ϐ��Ƃ��ĐU���킹��B
            slider.value = (float)currentEne / (float)maxEne; ;
            Debug.Log("slider.value : " + slider.value);

        }
    }
}