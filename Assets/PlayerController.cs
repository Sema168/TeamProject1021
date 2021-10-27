using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("敵のプレファブ")] public GameObject mirrorPrefab;
    [Header("移動速度")] public float speed;

    private Rigidbody2D rb = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal") * speed;
        float verticalKey = Input.GetAxis("Vertical") * speed;

        //移動処理
        rb.velocity = new Vector2(horizontalKey, verticalKey);

        //マウスの方を向く処理
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //鏡を取った時、その鏡を装備する
        if (collision.tag == "ItemMirror")
        {
            GameObject item = transform.Find("Weapon").gameObject;
            GameObject weapon = Instantiate(mirrorPrefab, item.transform.position, item.transform.rotation) as GameObject;
            weapon.transform.parent = item.transform;
        }
    }
}
