using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���˂��鏈��
/// </summary>
public class Bounce : MonoBehaviour
{
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, coll.contacts[0].normal);
        this.rb.velocity = refrectVec;
    }
}
