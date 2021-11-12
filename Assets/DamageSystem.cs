using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI�g���Ƃ��͖Y�ꂸ�ɁI
using UnityEngine.UI;

public class DamageSystem : MonoBehaviour
{

    //�ő�HP�A���[�Ȑ��ɂ���
    [SerializeField]
    int maxHP = 137;
    //���݂�HP
    [SerializeField]
    float currentHP;

    GameObject textObj;
    Text text;
    GameObject hpSystem;

    void Start()
    {
        //Text��GameObject�Ƃ��Ď擾����
        textObj = GameObject.Find("Text");
        //HPSystem���擾����
        hpSystem = GameObject.Find("HPSystem");
    }

    void Update()
    {
        //Text��Text�R���|�[�l���g�ɃA�N�Z�X
        //(int)��float�𐮐��ŕ\�����邽�߂̂���
        textObj.GetComponent<Text>().text = ((int)currentHP).ToString();

        //HPSystem�̃X�N���v�g��HPDown�֐���2�̐��l�𑗂�
        hpSystem.GetComponent<HPSystem>().HPDown(currentHP, maxHP);
    }

    //FixedUpdate�͈��ɌĂ΂��̂Ŏ����I�Ɏg�������ɗǂ��炵��
    void FixedUpdate()
    {
        //currentHP��0�ȏ�Ȃ�True
        if (0 <= currentHP)
        {
            //maxHP����b���i�~10�j������������currentHP
            currentHP = maxHP - Time.time * 10;
        }
    }
}