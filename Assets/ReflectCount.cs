using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectCount : MonoBehaviour
{
    public PlayerController player;
    int count;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision .gameObject .tag == "Laser")
        {
            count++;
            Debug.Log("‚Ô‚Â‚©‚Á‚½");
        }
    }

    void Update()
    {
        if (count >= 5)
        {
            player.mirror.SetActive(false );
            player.convexMirror.SetActive(false);
            player.concaveMirror.SetActive(false);
            count = 0;
        }
    }
}
