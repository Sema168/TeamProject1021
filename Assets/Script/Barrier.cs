using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [Header("バリア")] public GameObject barrier;
    /// <summary>
    /// バリアの持続時間
    /// </summary>
    private float barrierTime = 10.0f;

    public void BarrierSkill()
    {
        barrier.SetActive(true);
        Invoke(nameof(BarrierEnd), barrierTime);
    }
    
    void BarrierEnd()
    {
        barrier.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider .tag == "Laser")
        {
            Destroy(collider.gameObject);
        }
    }
}
