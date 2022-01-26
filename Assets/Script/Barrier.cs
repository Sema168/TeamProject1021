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
    private bool isBarrierSkill = false;

    private float activeTime = 0.0f;
    private float blinkTime = 0.0f;
    private float blinkStartTime = 7.0f;
    private SpriteRenderer sr = null;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isBarrierSkill)
        {
            BarrierBlink();
        }
    }

    public void BarrierSkill()
    {
        isBarrierSkill = true;
        barrier.SetActive(true);
        Invoke(nameof(BarrierEnd), barrierTime);
    }
    
    void BarrierEnd()
    {
        isBarrierSkill = false;
        barrier.SetActive(false);
    }

    public void BarrierBlink()
    {
        activeTime += Time.deltaTime;
        Debug.Log(activeTime);
        if (activeTime > blinkStartTime)
        {
            if (blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            else if (blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            else
            {
                sr.enabled = true;
            }

            if (activeTime > barrierTime)
            {
                sr.enabled = true;
                activeTime = 0.0f;
                blinkTime = 0.0f;
            }
            else
            {
                blinkTime += Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider .tag == "Laser")
        {
            Destroy(collider.gameObject);
        }
    }

}
