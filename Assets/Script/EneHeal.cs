using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneHeal : MonoBehaviour
{
    [Header("EneBarのスクリプト")] public EneBar eneBar;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            eneBar.EneHeal();
        }
    }
}
