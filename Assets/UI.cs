using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject heal;
    public GameObject barrier;
    public GameObject increace;
    int count = 0;
    int skillNum = 0;



    void Start()
    {
        heal.SetActive(false);
        barrier .SetActive(false);
        increace .SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            skillNum = count % 3;
            if (skillNum == 1)
            {
                heal.SetActive(true);
                barrier.SetActive(false);
                increace.SetActive(false);
                Debug.Log("âÒïú");
            }
            else if (skillNum == 2)
            {
                heal.SetActive(false);
                barrier.SetActive(true);
                increace.SetActive(false);
                Debug.Log("ÉoÉäÉA");

            }
            else if (skillNum == 0)
            {
                heal.SetActive(false);
                barrier.SetActive(false);
                increace.SetActive(true);
                Debug.Log("ï™êg");

            }

        }
    }
}
