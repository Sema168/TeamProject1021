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
        //�}�E�X�̕�����������
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;

        //Stock = mirrorStock + convexMirrorStock + concaveMirrorStock;
        //if (Stock > 3)
        //{

        //}

        //�X�y�[�X�L�[�ŋ���؂�ւ���(�v���k)
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

   �@void OnTriggerEnter2D(Collider2D collision)
    {
        //������������A���̋��𑕔����� or �����X�g�b�N����(�v���k)
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
