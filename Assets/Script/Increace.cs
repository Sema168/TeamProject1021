using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increace : MonoBehaviour
{
    public GameObject decoyPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void DecoyInstace()
    {
        GameObject decoy = Instantiate(decoyPrefab);
    }
}
