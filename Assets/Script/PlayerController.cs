using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("鏡")] public GameObject mirror;
    [Header("凸面鏡")] public GameObject convexMirror;
    [Header("凹面鏡")] public GameObject concaveMirror;
    [Header("移動速度")] public float speed;

    private Rigidbody2D rb;
    private int count = 0;
    private int mirrorNum = 0;

    public bool isDamage = false;
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private SpriteRenderer sr = null;

    //鏡の所持数
    private int stock;
    private int maxStock = 3;
    [System.NonSerialized] public int mirrorStock;
    [System.NonSerialized] public int convexMirrorStock;
    [System.NonSerialized] public int concaveMirrorStock;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        stock = mirrorStock + concaveMirrorStock + convexMirrorStock;

        //マウスの方を向く処理
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;

        MirrorChenge();

        Flashing();
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
        //鏡を取った時、その鏡をストックする
        if (collision.tag == "ItemMirror")
        {
            if (stock < maxStock)
            {
                mirrorStock++;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "ItemConvexMirror")
        {
            if (stock < maxStock)
            {
                convexMirrorStock++;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "ItemConcaveMirror")
        {
            if (stock < maxStock)
            {
                concaveMirrorStock++;
            }
            Destroy(collision.gameObject);
        }
    }

    /// <summary>
    /// 鏡の切り替え
    /// </summary>
    void MirrorChenge()
    {
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

    public void Flashing()
    {
        if (isDamage)
        {
            //明滅　ついている時に戻る
            if (blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            //明滅　消えているとき
            else if (blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            //明滅　ついているとき
            else
            {
                sr.enabled = true;
            }

            //1秒たったら明滅終わり
            if (continueTime > 1.0f)
            {
                isDamage = false;
                blinkTime = 0f;
                continueTime = 0f;
                sr.enabled = true;
                GetComponent<CircleCollider2D>().isTrigger = false;
            }
            else
            {
                blinkTime += Time.deltaTime;
                continueTime += Time.deltaTime;
                GetComponent<CircleCollider2D>().isTrigger = true;
            }

        }
    }
}
