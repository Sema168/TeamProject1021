using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMirror : MonoBehaviour
{
    private float dropTime = 0.0f;
    private float blinkTime = 0.0f;
    private float blinkStartTime = 18.0f;
    private float destroyTime = 20.0f;
    private SpriteRenderer sr = null;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        dropTime += Time.deltaTime;

        if (dropTime > blinkStartTime)
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

            if (dropTime > destroyTime)
            {
                sr.enabled = true;
                Destroy(gameObject);
            }
            else
            {
                blinkTime += Time.deltaTime;
            }
        }
    }
}
