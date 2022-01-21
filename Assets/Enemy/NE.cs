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

    //一秒ごとに弾を発射するためのもの
    bool ha = true;
    private float targetTime = 1.0f;
    private float currentTime = 0;
    public int speed = 5;  //オブジェクトが自動で動くスピード調整
    Vector3 movePosition;//②オブジェクトの目的地を保存
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

            //アイテムの落ちる確率
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
            //一秒経つごとに弾を発射する
            currentTime += Time.deltaTime;
            if (targetTime < currentTime)
            {
                currentTime = 0;
                ////敵の座標を変数posに保存
                Vector3 pos = enemy.transform.position;
                Vector3 poy = player.transform.position;
                Vector3 po = enemy.transform.position + (enemy.transform.position * 0.3f);

                var t = Instantiate(tama, po, Quaternion.identity) as GameObject;
                //弾のプレハブの位置を敵の位置にする
                t.transform.position = pos;
                //敵からプレイヤーに向かうベクトルをつくる
                //プレイヤーの位置から敵の位置（弾の位置）を引く
                Vector3 vec = poy - pos;
                //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
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
        //hitしたら新しい座標を代入します

        if (movePosition == enemy.transform.position)  //②playerオブジェクトが目的地に到達すると、
        {
            movePosition = moveRandomPosition();  //②目的地を再設定
        }
        //else if (hit.collider.tag == "syo")
        //{
        //    Debug.Log("ihfpid");
        //        movePosition = sin();
        //}
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
