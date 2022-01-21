using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;
    public Transform borderTop2;
    public Transform borderBottom2;
    public Transform borderLeft2;
    public Transform borderRight2;
    //éûä‘êßå¿ÇÃïœêî
    float o;
    float j;
    float i;
    bool q = true;

    void Start()
    {


        //InvokeRepeating("ad", 20, 15);


    }

    void Update()
    {
        j += Time.deltaTime;
        i += Time.deltaTime;
        o += Time.deltaTime;
        //éOïbàÍâÒ
        if (j >= 5)
        {
            j = 0;
            //50ïbÇ…åoÇ¡ÇΩÇÁàÍïbàÍâÒ
            if (o >= 50)
            {
                j = 2;
            }
            Enemy();
            Enemy2L();
        }
        //20ïbàÍâÒ
        if (i >= 20)
        {
            i = 0;
            if (o >= 50)
            {
                i = 10;
            }
            ad();
            Enemy2R();
        }




    }
    void Enemy()
    {
        // ç∂âEÁ≤ûyîVä‘ìIà íu
        int x = (int)Random.Range(borderLeft.position.x + 1,
                          borderRight.position.x - 1);

        // y è„â∫Á≤ûyîVä‘ìIà íu
        int y = (int)Random.Range(borderBottom.position.y + 1,
                                  borderTop.position.y - 1);

        Instantiate(enemy,
                  new Vector2(x, y),
                  Quaternion.identity);


    }

    void ad()
    {
        // ç∂âEÁ≤ûyîVä‘ìIà íu
        int a = (int)Random.Range(borderLeft2.position.x + 1,
          borderRight2.position.x - 1);

        // y è„â∫Á≤ûyîVä‘ìIà íu
        int b = (int)Random.Range(borderBottom2.position.y + 1,
                                  borderTop2.position.y - 1);
        Instantiate(enemy,
                  new Vector2(a, b),
                  Quaternion.identity);
    }
    void Enemy2L()
    {
        // ç∂âEÁ≤ûyîVä‘ìIà íu
        int x = (int)Random.Range(borderLeft.position.x + 1,
                          borderRight.position.x - 1);

        // y è„â∫Á≤ûyîVä‘ìIà íu
        int y = (int)Random.Range(borderBottom.position.y + 1,
                                  borderTop.position.y - 1);

        Instantiate(enemy2,
                  new Vector2(x, y),
                  Quaternion.identity);
    }
    void Enemy2R()
    {
        int a = (int)Random.Range(borderLeft2.position.x + 1,
  borderRight2.position.x - 1);

        // y è„â∫Á≤ûyîVä‘ìIà íu
        int b = (int)Random.Range(borderBottom2.position.y + 1,
                                  borderTop2.position.y - 1);
        Instantiate(enemy2,
                  new Vector2(a, b),
                  Quaternion.identity);
    }
}
