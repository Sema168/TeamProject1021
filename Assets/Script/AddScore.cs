using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [Header("�X�R�A�X�N���v�g")] public Score score;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            score.score += 100;
            Debug.Log(score);
        }
    }
}
