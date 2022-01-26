using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increace : MonoBehaviour
{
    public GameObject SubPrefab;
    private float destroyTime = 15.0f; 
    
    public void DecoyInstance()
    {
        GameObject spawnArea = transform.Find("SubSpawnArea").gameObject;
        GameObject decoy = Instantiate(SubPrefab,spawnArea.transform .position,spawnArea.transform.rotation);
        Destroy(decoy.gameObject,destroyTime);
    }
}
