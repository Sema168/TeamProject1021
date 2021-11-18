using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvexMirror : MonoBehaviour
{
    [Header("�G�̒e")] public GameObject laserPrefab;

    private float timeleft;

    void Update()
    {
        timeleft -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            //�A���Ŕ������Ȃ��悤�ɂ���(0.2�b����)
            if (timeleft <= 0.0)
            {
                timeleft = 0.2f;

                GameObject newLaser = Instantiate(laserPrefab, collision.transform.position, collision.transform.rotation);
                newLaser.GetComponent<CircleCollider2D>().isTrigger = true;
                newLaser.GetComponent<Rigidbody2D>().velocity = -GetComponent<Rigidbody2D>().velocity;
            }
        }
    }
}
