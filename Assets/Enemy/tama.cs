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
        transform.Translate(Vector3.up * Time.deltaTime);
        Destroy(this.gameObject, 5.0f);
    }
}
