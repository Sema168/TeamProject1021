using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [Header("�o���A")] public GameObject barrier;
    /// <summary>
    /// �o���A�̎�������
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
