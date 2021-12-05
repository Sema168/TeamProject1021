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
    private int count = 0;
    private int mirrorNum = 0;

    //鏡の所持数
    int Stock;
    public int mirrorStock = 1;
    public int convexMirrorStock = 1;
    public int concaveMirrorStock = 1;

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

        //Stock = mirrorStock + convexMirrorStock + concaveMirrorStock;
        //if (Stock > 3)
        //{

        //}

        //スペースキーで鏡を切り替える(要相談)
        if (Input.GetKeyDown("space"))
        {
            count++;
            mirrorNum = count % 3;
            if (mirrorNum == 1 && mirrorStock > 0)
            {
                mirror.SetActive(true);
                convexMirror.SetActive(false);
                concaveMirror.SetActive(false);
            }
            else if (mirrorNum == 2 && convexMirrorStock > 0)
            {
                mirror.SetActive(false);
                convexMirror.SetActive(true);
                concaveMirror.SetActive(false);
            }
            else if (mirrorNum == 0 && concaveMirrorStock > 0)
            {
                mirror.SetActive(false);
                convexMirror.SetActive(false);
                concaveMirror.SetActive(true);
            }
        }
    }

    void FixedUpdate()
    {
        float horizontalKey = Input.GetAxis("Horizontal") * speed;
        float verticalKey = Input.GetAxis("Vertical") * speed;

        //移動処理
        rb.velocity = new Vector2(horizontalKey, verticalKey);
    }

   　void OnTriggerEnter2D(Collider2D collision)
    {
        //鏡を取った時、その鏡を装備する or 鏡をストックする(要相談)
        if (collision.tag == "ItemMirror")
        {
            //mirror.SetActive(true);
            //convexMirror.SetActive(false);
            //concaveMirror.SetActive(false);
            
            Destroy(collision.gameObject);
            mirrorStock++;
            Debug.Log(mirrorStock);

        }
        else if (collision.tag == "ItemConvexMirror")
        {
            //mirror.SetActive(false);
            //convexMirror.SetActive(true);
            //concaveMirror.SetActive(false);
            convexMirrorStock++;
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "ItemConcaveMirror")
        {
            //mirror.SetActive(false);
            //convexMirror.SetActive(false);
            //concaveMirror.SetActive(true);
            concaveMirrorStock++;
            Destroy(collision.gameObject);
        }
    }
}
