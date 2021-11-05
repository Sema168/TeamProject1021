using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMirrorTriggerCheck: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Playerタグがついたオブジェクトが触れると消す
        if (collision.tag == "Player") 
        {
            Destroy(gameObject);
        }
    }
}
