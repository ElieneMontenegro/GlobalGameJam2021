using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject malaPrefab;
    public float respawnTime = 1f;
    private float[] YValues = { -7.33f, -19.37f, -31.19f };
    private float value;


    private void Start()
    {
        StartCoroutine(MalaSpawning());
    }

    void GetRandom()
    {
        int random = Random.Range(0, 3);
        value = YValues[random];
    }

    private void SpawnEnemy()
    {
        GetRandom();
        GameObject mala = Instantiate(malaPrefab) as GameObject;
        mala.transform.position = new Vector2(70, value);
    }

    IEnumerator MalaSpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}

    
