using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increace : MonoBehaviour
{
    public GameObject SubPrefab;
    private float destroyTime = 15.0f;
    public void DecoyInstance()
    {
        GameObject weapon = transform.Find("SubSpawnArea").gameObject;
        GameObject decoy = Instantiate(SubPrefab,weapon.transform .position,weapon.transform.rotation);
        Destroy(decoy.gameObject,destroyTime);
    }
}
