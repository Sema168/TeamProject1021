using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTriggerCheck : MonoBehaviour
{
    /// <summary>
    /// ���[�U�[(�e�I�u�W�F�N�g)
    /// </summary>
    private GameObject root;

    void Start()
    {
        //�e�̃I�u�W�F�N�g��߂܂���
        root = transform.root.gameObject;
    }

    //�e���d�Ȃ鎞�͂��蔲���A�����Ɠ����蔻��𓾂�
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser" || collision.tag == "Lava")
        {
            root.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Laser" || collision.tag == "Lava")
        {
            root.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Laser" || collision.tag == "Lava")
        {
            root.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
