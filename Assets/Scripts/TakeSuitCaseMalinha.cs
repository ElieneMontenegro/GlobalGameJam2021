using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeSuitCaseMalinha : MonoBehaviour
{
    malaSpawner malas;

    private void Start()
    {
        malas = GetComponent<malaSpawner>();
    }

    private void Update()
    {
        DevolverMalinha();
    }

    private void DevolverMalinha()
    {
        if(this.transform.position.x == -9.36f && this.transform.position.y == -5.96)
        {
            malas.SpawnMala();
        }
    }


}
