using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ”½Ë‚·‚éˆ—
/// </summary>
public class Bounce : MonoBehaviour
{
    private Vector2 lastVelocity;
    private Rigidbody2D rb;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();

        //Ÿè‚É“®‚©‚·‚½‚ß‚ÌƒvƒƒOƒ‰ƒ€AŒã‚Ù‚ÇÁ‚µ‚Ü‚·
        rb.velocity = new Vector2(0, 4);
    }

    void FixedUpdate()
    {
        this.lastVelocity = this.rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, coll.contacts[0].normal);
        this.rb.velocity = refrectVec;
    }
}
