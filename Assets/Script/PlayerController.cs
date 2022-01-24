using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("��")] public GameObject mirror;
    [Header("�ʖʋ�")] public GameObject convexMirror;
    [Header("���ʋ�")] public GameObject concaveMirror;
    [Header("�ړ����x")] public float speed;
    [Header("�o���A")] public GameObject barrier;

    private Rigidbody2D rb;
    private int count = 0;
    private int mirrorNum = 0;

    //�_���[�W��̓_�ł̕ϐ�
    [System.NonSerialized] public bool isDamage = false;
    private float damageTime = 0.0f;
    private float blinkTime = 0.0f;
    private SpriteRenderer sr = null;

    //���̏�����
    private int currentStock;
    private int maxStock = 3;
    [System.NonSerialized] public int mirrorStock = 1;
    [System.NonSerialized] public int convexMirrorStock = 1;
    [System.NonSerialized] public int concaveMirrorStock = 1;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        currentStock = mirrorStock + concaveMirrorStock + convexMirrorStock;

        //�}�E�X�̕�����������
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;

        if (Input.GetKeyDown("space"))
        {
            MirrorChenge();
        }

        if (isDamage)
        {
            Flashing();
        }
    }

    void FixedUpdate()
    {
        float horizontalKey = Input.GetAxis("Horizontal") * speed;
        float verticalKey = Input.GetAxis("Vertical") * speed;

        //�ړ�����
        rb.velocity = new Vector2(horizontalKey, verticalKey);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //������������A���̋����X�g�b�N����
        if (collision.tag == "ItemMirror")
        {
            if (currentStock < maxStock)
            {
                mirrorStock++;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "ItemConvexMirror")
        {
            if (currentStock < maxStock)
            {
                convexMirrorStock++;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "ItemConcaveMirror")
        {
            if (currentStock < maxStock)
            {
                concaveMirrorStock++;
            }
            Destroy(collision.gameObject);
        }
    }

    /// <summary>
    /// ���̐؂�ւ�
    /// </summary>
    void MirrorChenge()
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

    public void Flashing()
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

        if (damageTime > 1.0f)
        {
            isDamage = false;
            blinkTime = 0f;
            damageTime = 0f;
            sr.enabled = true;
            barrier.SetActive(false);
        }
        else
        {
            blinkTime += Time.deltaTime;
            damageTime += Time.deltaTime;
            barrier.SetActive(true);
        }
    }
}
