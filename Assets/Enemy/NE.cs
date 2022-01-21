using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NE : MonoBehaviour
{
    GameObject player;
    public GameObject tama;
    public GameObject enemy;
    public GameObject item;
    public GameObject it;
    public GameObject Baku;

    //��b���Ƃɒe�𔭎˂��邽�߂̂���
    bool ha = true;
    private float targetTime = 1.0f;
    private float currentTime = 0;
    public int speed = 5;  //�I�u�W�F�N�g�������œ����X�s�[�h����
    Vector3 movePosition;//�A�I�u�W�F�N�g�̖ړI�n��ۑ�
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "syo")
        {
            movePosition = sin();
        }
        if (col.gameObject.tag == "Laser")
        {

            Score.score += 100;
            Instantiate(Baku, transform.position, Quaternion.identity);
            Destroy(gameObject);

            //�A�C�e���̗�����m��
            int rn = Random.Range(0, 5);
            int r = Random.Range(0, 10);

            if (rn == 3)
            {
                Vector3 ke = transform.position;
                Instantiate(item, ke, Quaternion.identity);

            }
            else if (r == 9)
            {
                Vector3 ke = transform.position;
                Instantiate(it, ke, Quaternion.identity);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "syo")
        {
            movePosition = sin();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ha = false;
            //��b�o���Ƃɒe�𔭎˂���
            currentTime += Time.deltaTime;
            if (targetTime < currentTime)
            {
                currentTime = 0;
                ////�G�̍��W��ϐ�pos�ɕۑ�
                Vector3 pos = enemy.transform.position;
                Vector3 poy = player.transform.position;
                Vector3 po = enemy.transform.position + (enemy.transform.position * 0.3f);

                var t = Instantiate(tama, po, Quaternion.identity) as GameObject;
                //�e�̃v���n�u�̈ʒu��G�̈ʒu�ɂ���
                t.transform.position = pos;
                //�G����v���C���[�Ɍ������x�N�g��������
                //�v���C���[�̈ʒu����G�̈ʒu�i�e�̈ʒu�j������
                Vector3 vec = poy - pos;
                //�e��RigidBody2D�R���|�l���g��velocity�ɐ�����߂��x�N�g�������ė͂�������
                t.GetComponent<Rigidbody2D>().velocity = vec;


            }


        }


    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        ha = true;
    }


    void idou()
    {


        RaycastHit2D hit = Physics2D.Raycast(transform.position, movePosition);
        Debug.DrawLine(transform.position, movePosition, Color.red);
        //hit������V�������W�������܂�

        if (movePosition == enemy.transform.position)  //�Aplayer�I�u�W�F�N�g���ړI�n�ɓ��B����ƁA
        {
            movePosition = moveRandomPosition();  //�A�ړI�n���Đݒ�
        }
        //else if (hit.collider.tag == "syo")
        //{
        //    Debug.Log("ihfpid");
        //        movePosition = sin();
        //}
        this.enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, movePosition, speed * Time.deltaTime);  //�@�Aplayer�I�u�W�F�N�g��, �ړI�n�Ɉړ�, �ړ����x

    }
    private Vector3 moveRandomPosition()  // �ړI�n�𐶐��Ax��y�̃|�W�V�����������_���ɒl���擾 
    {
        Vector3 randomPosi = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 5);
        return randomPosi;
    }
    private Vector3 sin()  // �ړI�n�𐶐��Ax��y�̃|�W�V�����������_���ɒl���擾 
    {
        Vector3 randomPosi = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 5);
        return randomPosi;
    }
}
