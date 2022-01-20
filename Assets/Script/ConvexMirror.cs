using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvexMirror : MonoBehaviour
{
    [Header("ìGÇÃíe")] public GameObject laserPrefab;
    /// <summary>
    /// íeÇÃë¨Ç≥
    /// </summary>
    private float  fowerdSpeed = 6.0f;
    private float sideSpeed;
    /// <summary>
    /// îΩéÀå„Ç…è¡Ç¶ÇÈéûä‘
    /// </summary>
    private float destroyTime = 1.5f;
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
            //òAë±Ç≈î≠ê∂ÇµÇ»Ç¢ÇÊÇ§Ç…Ç∑ÇÈ(0.2ïbÇ≤Ç∆)
            if (timeleft <= 0.0)
            {
                timeleft = 0.2f;
                //éŒÇﬂÇ…îΩéÀÇ∑ÇÈíeÇÃâ°ÇÃÉxÉNÉgÉãÇÃíl
                sideSpeed = fowerdSpeed / 2;

                //íeÇéOî≠Ç…ägéUÇ∑ÇÈ(Ç±ÇÃÉXÉNÉäÉvÉgÇä»ó™âªÇµÇΩÇ¢)
                GameObject newLaser = Instantiate(laserPrefab, collision.transform.position, collision.transform.rotation);
                newLaser.GetComponent<CircleCollider2D>().isTrigger = true;
                newLaser.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(sideSpeed , fowerdSpeed  ));
                GameObject newLaser2 = Instantiate(laserPrefab, collision.transform.position, collision.transform.rotation);
                newLaser2.GetComponent<CircleCollider2D>().isTrigger = true;
                newLaser2.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(-sideSpeed , fowerdSpeed  ));
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
