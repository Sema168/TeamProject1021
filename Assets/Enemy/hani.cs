using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hani : MonoBehaviour
{
    public GameObject player;
    public GameObject tama;
    public GameObject enemy;
    //��b���Ƃɒe�𔭎˂��邽�߂̂���
    bool ha = true;
    private float targetTime = 1.0f;
    private float currentTime = 0;
    public int speed = 5;  //�I�u�W�F�N�g�������œ����X�s�[�h����
    Vector3 movePosition;//�A�I�u�W�F�N�g�̖ړI�n��ۑ�
    void Start()
    {
        movePosition = moveRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (ha)
        {
            idou();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            ha = false;
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
    public void OnTriggerExit2D(Collider2D collision)
    {
        ha = true;
    }
    void idou()
    {

        if (movePosition == enemy.transform.position)  //�Aplayer�I�u�W�F�N�g���ړI�n�ɓ��B����ƁA
        {
            movePosition = moveRandomPosition();  //�A�ړI�n���Đݒ�
        }
        this.enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, movePosition, speed * Time.deltaTime);  //�@�Aplayer�I�u�W�F�N�g��, �ړI�n�Ɉړ�, �ړ����x

    }
    private Vector3 moveRandomPosition()  // �ړI�n�𐶐��Ax��y�̃|�W�V�����������_���ɒl���擾 
    {
        Vector3 randomPosi = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 5);
        return randomPosi;
    }

}
