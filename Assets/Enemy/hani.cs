using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hani : MonoBehaviour
{
    public GameObject player;
    public GameObject tama;
    //��b���Ƃɒe�𔭎˂��邽�߂̂���
    private float targetTime = 1.0f;
    private float currentTime = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            //��b�o���Ƃɒe�𔭎˂���
            currentTime += Time.deltaTime;
            if (targetTime < currentTime)
            {
                currentTime = 0;
                //�G�̍��W��ϐ�pos�ɕۑ�
                var pos = this.gameObject.transform.position;
                //�e�̃v���n�u���쐬
                var t = Instantiate(tama) as GameObject;
                //�e�̃v���n�u�̈ʒu��G�̈ʒu�ɂ���
                t.transform.position = pos;
                //�G����v���C���[�Ɍ������x�N�g��������
                //�v���C���[�̈ʒu����G�̈ʒu�i�e�̈ʒu�j������
                Vector2 vec = player.transform.position - pos;
                //�e��RigidBody2D�R���|�l���g��velocity�ɐ�����߂��x�N�g�������ė͂�������
                t.GetComponent<Rigidbody2D>().velocity = vec;



                //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed);

            }
            Destroy(GameObject.FindWithTag("tama"), 5.0f);

        }

    }
}
