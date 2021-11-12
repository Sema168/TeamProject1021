using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("鏡のプレファブ")] public GameObject mirror;
    [Header("凸面鏡のプレファブ")] public GameObject convexMirror;
    [Header("凹面鏡のプレファブ")] public GameObject concaveMirror;
    [Header("移動速度")] public float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        //マウスの方を向く処理
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;
    }

    void FixedUpdate()
    {
        float horizontalKey = Input.GetAxis("Horizontal") * speed;
        float verticalKey = Input.GetAxis("Vertical") * speed;

        //移動処理
        rb.velocity = new Vector2(horizontalKey, verticalKey);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //鏡を取った時、その鏡を装備する
        if (collision.tag == "ItemMirror")
        {
            mirror.SetActive(true);
            convexMirror.SetActive(false);
            concaveMirror.SetActive(false);
        }
        else if (collision.tag == "ItemConvexMirror")
        {
            mirror.SetActive(false);
            convexMirror.SetActive(true);
            concaveMirror.SetActive(false);
        }
        else if (collision.tag == "ItemConcaveMirror")
        {
            mirror.SetActive(false);
            convexMirror.SetActive(false);
            concaveMirror.SetActive(true);
        }
    }
}
