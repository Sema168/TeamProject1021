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
        //LookAt2D();
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Laser")
        {
            Score.score += 100;
            Destroy(gameObject);
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
                ////Debug.Log(po);
                ////�e�̃v���n�u���쐬

                //Vector3 test1 = pos - po;
                //transform.rotation = Quaternion.LookRotation(test1);
                ////pos.rotation = Quaternion.FromToRotation(Vector3.up, test1);
                //Vector3 test2 = poy - po;
                //float test3 = Vector3.Dot(test1.normalized, test2.normalized);
                //float test4 = Mathf.Acos(test3) * Mathf.Rad2Deg;
                //Debug.Log(test4);
                //var te = Vector3.Dot(pos.normalized, po.normalized);
                //var gh = Mathf.Acos(te) * Mathf.Rad2Deg;
                //if (test4 < 50)
                //{
                //    Debug.Log("����");
                //}
                //else
                //{
                    var t = Instantiate(tama, po, Quaternion.identity) as GameObject;
                    //�e�̃v���n�u�̈ʒu��G�̈ʒu�ɂ���
                    t.transform.position = pos;
                    //�G����v���C���[�Ɍ������x�N�g��������
                    //�v���C���[�̈ʒu����G�̈ʒu�i�e�̈ʒu�j������
                    Vector3 vec = poy - pos;
                    //�e��RigidBody2D�R���|�l���g��velocity�ɐ�����߂��x�N�g�������ė͂�������
                    t.GetComponent<Rigidbody2D>().velocity = vec;

                //}
            }
            Destroy(GameObject.FindWithTag("Laser"), 5.0f);

        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        ha = true;
    }

    //void LookAt2D()
    //{
    //    Vector3 distance = player.transform.position - this.transform.position; //�G�ƃv���C���[�̈ʒu�̍������
    //    float angle = Mathf.Atan2(distance.x, distance.y) * Mathf.Rad2Deg; //Mathf.Atan2��
    //    transform.eulerAngles = new Vector3(0, 0, -(angle-90));
    //}

    void idou()
    {


        RaycastHit2D hit = Physics2D.Raycast(transform.position, movePosition);
        Debug.DrawLine(transform.position, movePosition,Color.red);
        if (hit.collider.gameObject.name == "Square" || hit.collider.gameObject.name == "Square.1"|| hit.collider.gameObject.name == "Square.2"|| hit.collider.gameObject.name == "Square.3") 
        {
            movePosition =sin();
            Debug.Log(hit.collider.gameObject.name);
        }
        else
        {
         if (movePosition == enemy.transform.position)  //�Aplayer�I�u�W�F�N�g���ړI�n�ɓ��B����ƁA
         {
            movePosition = moveRandomPosition();  //�A�ړI�n���Đݒ�
         }

        }
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
