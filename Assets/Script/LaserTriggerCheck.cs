using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTriggerCheck : MonoBehaviour
{
   　private GameObject root;

    void Start()
    {
        //親のオブジェクトを捕まえる
        root = transform.root.gameObject;
    }

    //弾が重なる時はすり抜け、離れると当たり判定を得る
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser" || collision.tag == "Lava")
        {
            root.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Laser" || collision.tag == "Lava")
        {
            root.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Laser" || collision.tag == "Lava")
        {
            root.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
