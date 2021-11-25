using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvexMirror : MonoBehaviour
{
    [Header("敵の弾")] public GameObject laserPrefab;
    /// <summary>
    /// 弾の速さ
    /// </summary>
    float  fowerdSpeed = 6.0f;
    /// <summary>
    /// 斜めの速さの計算に使う値(ルート２)
    /// </summary>
    float root = Mathf.Sign(2);
    /// <summary>
    /// 反射後に消える時間
    /// </summary>
    private float destroyTime = 3.0f;
    private float timeleft;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            //連続で発生しないようにする(0.2秒ごと)
            if (timeleft <= 0.0)
            {
                timeleft = 0.2f;
                //斜めに反射する弾の縦と横のベクトルの値
                float sideSpeed = fowerdSpeed / root;

                //弾を三発に拡散する(このスクリプトを簡略化したい)
                GameObject newLaser = Instantiate(laserPrefab, collision.transform.position, collision.transform.rotation);
                newLaser.GetComponent<CircleCollider2D>().isTrigger = true;
                newLaser.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(sideSpeed , sideSpeed ));
                GameObject newLaser2 = Instantiate(laserPrefab, collision.transform.position, collision.transform.rotation);
                newLaser2.GetComponent<CircleCollider2D>().isTrigger = true;
                newLaser2.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(-sideSpeed , sideSpeed ));
                GameObject newLaser3 = Instantiate(laserPrefab, collision.transform.position, collision.transform.rotation);
                newLaser3.GetComponent<CircleCollider2D>().isTrigger = true;
                newLaser3.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(0, fowerdSpeed ));
                Destroy(collision.gameObject);
                Destroy(newLaser, destroyTime);
                Destroy(newLaser2, destroyTime );
                Destroy(newLaser3, destroyTime );
            }
        }
    }
}
