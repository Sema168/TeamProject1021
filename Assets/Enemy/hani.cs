using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hani : MonoBehaviour
{
    public GameObject player;
    public GameObject tama;
    public GameObject enemy;
    //一秒ごとに弾を発射するためのもの
    bool ha = true;
    private float targetTime = 1.0f;
    private float currentTime = 0;
    public int speed = 5;  //オブジェクトが自動で動くスピード調整
    Vector3 movePosition;//②オブジェクトの目的地を保存
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
            //一秒経つごとに弾を発射する
            currentTime += Time.deltaTime;
            if (targetTime < currentTime)
            {
                currentTime = 0;
                ////敵の座標を変数posに保存
                Vector3 pos = enemy.transform.position;
                Vector3 poy = player.transform.position;
                Vector3 po = enemy.transform.position + (enemy.transform.position * 0.3f);
                ////Debug.Log(po);
                ////弾のプレハブを作成

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
                //    Debug.Log("当た");
                //}
                //else
                //{
                    var t = Instantiate(tama, po, Quaternion.identity) as GameObject;
                    //弾のプレハブの位置を敵の位置にする
                    t.transform.position = pos;
                    //敵からプレイヤーに向かうベクトルをつくる
                    //プレイヤーの位置から敵の位置（弾の位置）を引く
                    Vector3 vec = poy - pos;
                    //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
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
    //    Vector3 distance = player.transform.position - this.transform.position; //敵とプレイヤーの位置の差を取る
    //    float angle = Mathf.Atan2(distance.x, distance.y) * Mathf.Rad2Deg; //Mathf.Atan2は
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
         if (movePosition == enemy.transform.position)  //②playerオブジェクトが目的地に到達すると、
         {
            movePosition = moveRandomPosition();  //②目的地を再設定
         }

        }
        this.enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, movePosition, speed * Time.deltaTime);  //①②playerオブジェクトが, 目的地に移動, 移動速度

    }
    private Vector3 moveRandomPosition()  // 目的地を生成、xとyのポジションをランダムに値を取得 
    {
        Vector3 randomPosi = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 5);
        return randomPosi;
    }
    private Vector3 sin()  // 目的地を生成、xとyのポジションをランダムに値を取得 
    {
        Vector3 randomPosi = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 5);
        return randomPosi;
    }

}
