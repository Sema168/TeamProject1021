using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector2 lastVelocity;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(IsTrigger());
    }

    void FixedUpdate()
    {
        lastVelocity = this.rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mirror")
        {
            Reflect(collision);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            //敵にダメージを与える処理
            Debug.Log("敵にダメージを与えた！");
            Destroy(gameObject);

        }
        else if (collision.gameObject.tag == "Laser")
        {
            //Destroy対策
        }
        else
        {
            Destroy(gameObject);
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
        Destroy(gameObject, 3.0f);
    }

    private IEnumerator IsTrigger()
    {
        yield return new WaitForSeconds(0.2f);

        GetComponent<CircleCollider2D>().isTrigger = false;
    }
}
