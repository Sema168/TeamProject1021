using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;
    void Start()
    {
        InvokeRepeating("Enemy", 3, 5);
    }

    void Update()
    {
        
    }
    void Enemy()
    {
        int x = (int)Random.Range(borderLeft.position.x + 1,
                          borderRight.position.x - 1);

        // y è„â∫Á≤ûyîVä‘ìIà íu
        int y = (int)Random.Range(borderBottom.position.y + 1,
                                  borderTop.position.y - 1);
        Instantiate(enemy,
                  new Vector2(x, y),
                  Quaternion.identity);
    }
}
