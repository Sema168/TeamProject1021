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
    }

    void FixedUpdate()
    {
        float horizontalKey = Input.GetAxis("Horizontal") * speed;
        float verticalKey = Input.GetAxis("Vertical") * speed;

        //�ړ�����
        rb.velocity = new Vector2(horizontalKey, verticalKey);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //������������A���̋��𑕔�����
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
