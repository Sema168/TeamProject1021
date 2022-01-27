using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPlayerController : MonoBehaviour
{
    [Header("鏡")] public GameObject mirror;
    [Header("凸面鏡")] public GameObject convexMirror;
    [Header("凹面鏡")] public GameObject concaveMirror;
    [Header("移動速度")] public float speed;

    private GameObject player;
    private GameObject playerMirror;
    private GameObject playerConvexMirror;
    private GameObject playerConcaveMirror;
    private Rigidbody2D rb;

    //ダメージ後の点滅の変数
    private float activeTime = 0.0f;
    private float blinkTime = 0.0f;
    private float blinkStartTime = 13.0f;
    private float destroyTime = 15.0f;
    private SpriteRenderer sr = null;


    void Start()
    {
        player = GameObject.Find("Player");
        playerMirror = GameObject.Find("Player/Weapon/Mirror");
        playerConvexMirror = GameObject.Find("Player/Weapon/ConvexMirror");
        playerConcaveMirror = GameObject.Find("Player/Weapon/ConcaveMirror");
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        this.transform.localRotation = player.transform.localRotation;

        MirrorChange();

        Flashing();
    }

    void FixedUpdate()
    {
        float horizontalKey = Input.GetAxis("Horizontal") * speed;
        float verticalKey = Input.GetAxis("Vertical") * speed;

        //移動処理
        rb.velocity = new Vector2(horizontalKey, verticalKey);
    }

    void MirrorChange()
    {
        if (playerMirror.activeSelf)
        {
            mirror.SetActive(true);
            convexMirror.SetActive(false);
            concaveMirror.SetActive(false);
        }
        else if (playerConvexMirror.activeSelf)
        {
            mirror.SetActive(false);
            convexMirror.SetActive(true);
            concaveMirror.SetActive(false);
        }
        else if (playerConcaveMirror.activeSelf)
        {
            mirror.SetActive(false);
            convexMirror.SetActive(false);
            concaveMirror.SetActive(true);
        }
    }


    void Flashing()
    {
        activeTime += Time.deltaTime;

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

            if (activeTime > destroyTime)
            {
                Destroy(gameObject);
            }
            else
            {
                blinkTime += Time.deltaTime;
            }
        }
    }
}
