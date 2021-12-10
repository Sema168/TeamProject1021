using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tama : MonoBehaviour
{
    public GameObject player;
    public float speed;

    void Start()
    {
        //Transform pz = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.up
        //transform.Translate(player.transform.position * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed);
        Destroy(this.gameObject, 5.0f);
    }
}
