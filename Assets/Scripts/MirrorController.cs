using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorController : MonoBehaviour
{
    //�~���[�̋����𐧌䂷��X�N���v�g�ł��B
    //�v���C���[�̎���ɐ������ꂽ�����}�E�X�̓����ɕ����ē������܂�
    //���̓v���C���[�̎q�I�u�W�F�N�g�ɂ��Ă���̂œ������������܂�

    Plane plane = new Plane();
    float distance = 0;

    void Start()
    {
        // 2D�͍������ς��Ȃ��̂ŁA�p�����[�^�X�V�����g���܂킵�Ă����Ȃ��͂�
        plane.SetNormalAndPosition(Vector3.back, transform.localPosition);
    }

    void Update()
    {
        // �}�E�X�̈ʒu������Plane�ւ̋������擾
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            //Plane�Ƃ̌�_�����߂āA�L�����N�^�[��������
            var lookPoint = ray.GetPoint(distance); ;
            transform.LookAt(transform.localPosition + Vector3.forward, lookPoint - transform.localPosition);
        }
    }
}
