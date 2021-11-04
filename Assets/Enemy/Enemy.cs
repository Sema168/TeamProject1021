using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;  //�@�����������I�u�W�F�N�g���C���X�y�N�^�[��������B
    //public GameObject tama;
    public float shotSpeed;
    public int speed = 5;  //�I�u�W�F�N�g�������œ����X�s�[�h����
    Vector3 movePosition;  //�A�I�u�W�F�N�g�̖ړI�n��ۑ�
    Vector3 zb;


    void Start()
    {
        movePosition = moveRandomPosition();  //�A���s���A�I�u�W�F�N�g�̖ړI�n��ݒ�
        InvokeRepeating("dasu", 3, 3);
    }

    void Update()
    {
        

        if (movePosition == enemy.transform.position)  //�Aplayer�I�u�W�F�N�g���ړI�n�ɓ��B����ƁA
        {
            movePosition = moveRandomPosition();  //�A�ړI�n���Đݒ�
        }
        this.enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, movePosition, speed * Time.deltaTime);  //�@�Aplayer�I�u�W�F�N�g��, �ړI�n�Ɉړ�, �ړ����x
    }

    private Vector3 moveRandomPosition()  // �ړI�n�𐶐��Ax��y�̃|�W�V�����������_���ɒl���擾 
    {
        Vector3 randomPosi = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 5);
        return randomPosi;
    }
    //public void dasu()
    //{


    //    zb = transform.position;
    //    zb.y += 1.0f; // �v���C���[��y���W + 1�̈ʒu�ɒe�𐶐�����

    //    Instantiate(tama, zb, Quaternion.identity);

    //}
}
