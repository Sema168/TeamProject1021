using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneHeal : MonoBehaviour
{
    [Header("EneBar�̃X�N���v�g")] public EneBar eneBar;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            eneBar.EneHeal();
        }
    }
}