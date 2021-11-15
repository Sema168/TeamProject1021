using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTriggerCheck : MonoBehaviour
{
    public GameObject root;

    void Start()
    {
        //親のオブジェクトを捕まえる
        root = transform.root.gameObject;
    }

    //弾が重なる時はすり抜け、離れると当たり判定を得る
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            root.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            root.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            root.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
