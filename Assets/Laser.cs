using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("敵の弾")] public GameObject laserPrefab;

    private Vector2 lastVelocity;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //勝手に動かすためのプログラム、後ほど消します
        rb.velocity = new Vector2(0, 4);
    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mirror")
        {
            Reflect(collision);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("敵にダメージを与えた！");
        }
        else
        {
            Debug.Log("鏡、敵以外に触れた！");
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }


    /// <summary>
    /// 反射する
    /// </summary>
    /// <param name="collision"></param>
    void Reflect(Collision2D collision)
    {
        Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, collision.contacts[0].normal);
        this.rb.velocity = refrectVec;
    }
}
