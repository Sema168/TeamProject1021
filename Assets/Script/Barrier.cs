using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [Header("ƒoƒŠƒA")] public GameObject barrier;
    private float barrierTime = 10.0f;

    private float activeTime = 0.0f;
    private float blinkTime = 0.0f;
    private float blinkStartTime = 8.0f;
    private SpriteRenderer sr = null;
    [System.NonSerialized] public bool isBarrierSkill = false;

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
        sr.enabled = true;
        activeTime = 0.0f;
        blinkTime = 0.0f;
        barrier.SetActive(false);
    }

    void BarrierBlink()
    {
        activeTime += Time.deltaTime;

        if (activeTime > blinkStartTime)
        {
            blinkTime += Time.deltaTime;

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
