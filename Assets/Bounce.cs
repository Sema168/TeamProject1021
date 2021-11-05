using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 反射する処理
/// </summary>
public class Bounce : MonoBehaviour
{
    private Vector2 lastVelocity;
    private Rigidbody2D rb;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();

        //勝手に動かすためのプログラム、後ほど消します
        rb.velocity = new Vector2(0, 4);
    }

    void FixedUpdate()
    {
        this.lastVelocity = this.rb.velocity;
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag =="Mirror")
        {
            Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, coll.contacts[0].normal);
            this.rb.velocity = refrectVec;
        }
        else
        {
            Debug.Log("鏡以外に触れた！");
        }
    }
}
