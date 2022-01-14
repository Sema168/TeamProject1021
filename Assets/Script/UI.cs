using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image Image;
    public Sprite[] sprite;
    private int count = 0;
    private int skillNum;

    void Start()
    {
        Image = GetComponent<Image>();
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            count++;
            skillNum = count % 3;

            if (skillNum == 1)
            {
                Image.sprite = sprite[0];
            }
            else if (skillNum == 2)
            {
                Image.sprite = sprite[1];
            }
            else
            {
                Image.sprite = sprite[2];
            }
        }
    }
}
