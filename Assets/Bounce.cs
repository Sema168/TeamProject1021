using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 反射する処理
/// </summary>
public class Bounce : MonoBehaviour
{
    [Header("敵の弾")]public GameObject laserPrefab;

    private Vector2 lastVelocity;
    private Rigidbody2D rb = null;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

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
        //else if (collision.gameObject.tag == "ConvexMirror")
        //{
        //    GameObject newLaser = Instantiate(laserPrefab, this.transform.position, this.transform.rotation);
        //    Reflect(collision);
        //    Debug.Log("凸面鏡に触れた！");
        //}
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("敵にダメージを与えた！");
            Destroy(gameObject);
        }
        else
        {
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
