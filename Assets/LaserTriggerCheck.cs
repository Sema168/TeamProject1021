using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTriggerCheck : MonoBehaviour
{
    public GameObject root;

    void Start()
    {
        //�e�̃I�u�W�F�N�g��߂܂���
        root = transform.root.gameObject;
    }

    //�e���d�Ȃ鎞�͂��蔲���A�����Ɠ����蔻��𓾂�
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            root.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            root.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            root.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
