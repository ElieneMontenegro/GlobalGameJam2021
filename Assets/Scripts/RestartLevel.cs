using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    public static RestartLevel instance;
    public Transform respawnPoint;

    public GameObject playerPrefab;

    public void Awake()
    {
        instance = this;
    }

   public void Respawn()
    {
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }
}
