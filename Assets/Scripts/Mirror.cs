using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    //�~���[�̋����𐧌䂷��X�N���v�g�ł��B
    //�v���C���[�̎���ɐ������ꂽ�����}�E�X�̓����ɕ����ē������܂�
    //�v���C���[�ɂ��������̂����Đ��䂵�܂�

    

    void Update()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        var direction = Input.mousePosition - screenPos;
        var angle = GetAim(Vector3.zero, direction);
        transform.SetLocalEulerAnglesY(-angle + 90f);
    }

   public float GetAim(Vector2 from,Vector2 to)
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
