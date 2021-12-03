using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvexMirror : MonoBehaviour
{
    [Header("�G�̒e")] public GameObject laserPrefab;
    /// <summary>
    /// �e�̑���
    /// </summary>
    float  fowerdSpeed = 6.0f;
    /// <summary>
    /// �΂߂̑����̌v�Z�Ɏg���l(���[�g�Q)
    /// </summary>
    float root = Mathf.Sign(2);
    /// <summary>
    /// ���ˌ�ɏ����鎞��
    /// </summary>
    private float destroyTime = 3.0f;
    private float timeleft;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            //�A���Ŕ������Ȃ��悤�ɂ���(0.2�b����)
            if (timeleft <= 0.0)
            {
                timeleft = 0.2f;
                //�΂߂ɔ��˂���e�̏c�Ɖ��̃x�N�g���̒l
                float sideSpeed = fowerdSpeed / root;

                //�e���O���Ɋg�U����(���̃X�N���v�g���ȗ���������)
                GameObject newLaser = Instantiate(laserPrefab, collision.transform.position, collision.transform.rotation);
                newLaser.GetComponent<CircleCollider2D>().isTrigger = true;
                newLaser.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(sideSpeed , sideSpeed ));
                GameObject newLaser2 = Instantiate(laserPrefab, collision.transform.position, collision.transform.rotation);
                newLaser2.GetComponent<CircleCollider2D>().isTrigger = true;
                newLaser2.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(-sideSpeed , sideSpeed ));
                GameObject newLaser3 = Instantiate(laserPrefab, collision.transform.position, collision.transform.rotation);
                newLaser3.GetComponent<CircleCollider2D>().isTrigger = true;
                newLaser3.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(0, fowerdSpeed ));
                Destroy(collision.gameObject);
                Destroy(newLaser, destroyTime);
                Destroy(newLaser2, destroyTime );
                Destroy(newLaser3, destroyTime );
            }
        }
    }
}
