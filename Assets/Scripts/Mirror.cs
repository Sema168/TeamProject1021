using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    //ミラーの挙動を制御するスクリプトです。
    //プレイヤーの周りに生成された鏡をマウスの動きに併せて動かします
    //プレイヤーにも同じものをつけて制御します

    

    void Update()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        var direction = Input.mousePosition - screenPos;
        var angle = GetAim(Vector3.zero, direction);
        transform.SetLocalEulerAnglesY(-angle + 90f);
    }

   public float GetAim(Vector2 from,Vector2 to)
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
