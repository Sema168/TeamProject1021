using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class razerController : MonoBehaviour
{
    
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
      this.  transform.Translate(0f, -0.005f, 0f);
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit"); // ÉçÉOÇï\é¶Ç∑ÇÈ
    }
}
