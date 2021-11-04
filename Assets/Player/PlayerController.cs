using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("���̃v���t�@�u")] public GameObject mirrorPrefab;
    [Header("�ʖʋ��̃v���t�@�u")] public GameObject convexMirrorPrefab;
    [Header("���ʋ��̃v���t�@�u")] public GameObject concaveMirrorPrefab;
    [Header("�ړ����x")] public float speed;

    private Rigidbody2D rb = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal") * speed;
        float verticalKey = Input.GetAxis("Vertical")* speed;

        //�ړ�����
        rb.velocity = new Vector2(horizontalKey, verticalKey);

        //�}�E�X�̕�����������
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;
    }

    //���肷��܂ŃR�����g�A�E�g���Ă����܂�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //������������A���̋��𑕔�����
        if (collision.tag == "ItemMirror")
        {
            GameObject item = transform.Find("Weapon").gameObject;
            GameObject weapon = Instantiate(mirrorPrefab, item.transform.position, item.transform.rotation) as GameObject;
            weapon.transform.parent = item.transform;
        }
        else if (collision.tag == "ItemConvexMirror")
        {
            GameObject item = transform.Find("Weapon").gameObject;
            GameObject weapon = Instantiate(convexMirrorPrefab, item.transform.position, item.transform.rotation) as GameObject;
            weapon.transform.parent = item.transform;
        }
        else if (collision.tag == "ItemConcaveMirror")
        {
            GameObject item = transform.Find("Weapon").gameObject;
            GameObject weapon = Instantiate(concaveMirrorPrefab, item.transform.position, item.transform.rotation) as GameObject;
            weapon.transform.parent = item.transform;
        }
    }
}