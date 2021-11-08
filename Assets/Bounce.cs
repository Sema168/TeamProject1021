using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���˂��鏈��
/// </summary>
public class Bounce : MonoBehaviour
{
    //public GameObject laserPrefab;
    private Vector2 lastVelocity;
    private Rigidbody2D rb;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();

        //����ɓ��������߂̃v���O�����A��قǏ����܂�
        rb.velocity = new Vector2(0, 4);
    }

    void FixedUpdate()
    {
        this.lastVelocity = this.rb.velocity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mirror")
        {
            Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, collision.contacts[0].normal);
            this.rb.velocity = refrectVec;
        }
        //else if (collision.gameObject.tag == "ConvexMirror")
        //{
        //    GameObject newLaser = Instantiate(laserPrefab, this.transform.position, this.transform.rotation);
        //    Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, collision.contacts[0].normal);
        //    this.rb.velocity = refrectVec;
        //    Debug.Log("�ʖʋ��ɐG�ꂽ�I");
        //}
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("�G�Ƀ_���[�W��^�����I");
            Destroy(gameObject);
        }
        //else if (collision.gameObject.tag == "Laser"){}
        else
        {
            Debug.Log("���ȊO�ɐG�ꂽ�I");
        }
    }
}
