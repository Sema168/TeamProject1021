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
        lastVelocity = this.rb.velocity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mirror")
        {
            Reflect(collision);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            //敵にダメージを与える処理
            Debug.Log("敵にダメージを与えた！");
        }
        else if (collision.gameObject.tag == "Laser")
        {
            //Destroy対策
        }
        else
        {
            //Destroy(gameObject);
            Debug.Log("鏡、敵以外に触れた！");
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
