using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("���̃v���t�@�u")] public GameObject mirror;
    [Header("�ʖʋ��̃v���t�@�u")] public GameObject convexMirror;
    [Header("���ʋ��̃v���t�@�u")] public GameObject concaveMirror;
    [Header("�ړ����x")] public float speed;

    private Rigidbody2D rb;
    private int count = 0;
    private int mirrorNum = 0;

    //���̏�����
    private int stock;
    private int maxStock = 3;
    public int mirrorStock;
    public int convexMirrorStock;
    public int concaveMirrorStock;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        stock = mirrorStock + concaveMirrorStock + convexMirrorStock;

        //�}�E�X�̕�����������
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;

        //�X�y�[�X�L�[�ŋ���؂�ւ���
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

        //�ړ�����
        rb.velocity = new Vector2(horizontalKey, verticalKey);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //������������A���̋����X�g�b�N����
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
}
