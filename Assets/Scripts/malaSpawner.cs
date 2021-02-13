using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class malaSpawner : MonoBehaviour
{

    PlayerController player;

    public GameObject[] mala;

    private float[,] posicoes = { { 34.5f, -7.4f }, { 13.1f, -7.4f }, { -10.9f, -20f }, { -6.3f, -31.6f }, { 9.3f, -31.6f }, { 43.8f, -31.6f } };

    int value;

    float valueX;
    float valueY;

    private float respawnTime = 20f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();

        StartCoroutine(MalaSpawning());
    }


    void GetRandom()
    {
        int posicaoRandomica = Random.Range(0, 6);

        valueX = posicoes[posicaoRandomica,0];
        valueY = posicoes[posicaoRandomica, 1];
    }

    void GetRandomMalinha()
    {
        value = Random.Range(0, 4);
    }

    public void SpawnMala()
    {
        GetRandom();
        GetRandomMalinha();

        GameObject malinha = Instantiate(mala[value]) as GameObject;
        malinha.transform.position = new Vector2(valueX, valueY);


    }

    IEnumerator MalaSpawning()
    {
        SpawnMala();
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnMala();
        }
    }
}

