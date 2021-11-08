using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 反射する処理
/// </summary>
public class Bounce : MonoBehaviour
{
    //public GameObject laserPrefab;
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
        //    Debug.Log("凸面鏡に触れた！");
        //}
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("敵にダメージを与えた！");
            Destroy(gameObject);
        }
        //else if (collision.gameObject.tag == "Laser"){}
        else
        {
            Debug.Log("鏡以外に触れた！");
        }
    }
}
