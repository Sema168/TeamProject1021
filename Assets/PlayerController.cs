using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("ˆÚ“®‘¬“x")] public float speed;

    private Rigidbody2D rb = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal") * speed;
        float verticalKey = Input.GetAxis("Vertical") * speed;

        rb.velocity = new Vector2(horizontalKey, verticalKey);
    }
}
