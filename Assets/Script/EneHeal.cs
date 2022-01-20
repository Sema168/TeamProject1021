using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneHeal : MonoBehaviour
{
    [Header("EneBarのスクリプト")] public EneBar eneBar;
    [Header("凹面鏡")] public GameObject concaveMirror;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            eneBar.EneHeal();
            if (concaveMirror.activeSelf)
            {
                eneBar.EneHeal();
            }
        }
    }
}
