using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMirrorTriggerCheck: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player�^�O�������I�u�W�F�N�g���G���Ə���
        if (collision.tag == "Player") 
        {
            Destroy(gameObject);
        }
    }
}
