using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPoints : MonoBehaviour
{
    private int pontos = 0;

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "malinhaBoa")
        {
            pontos++;
            print(pontos);
            if (pontos == 2)
            {
                SceneManager.LoadScene(2);
            }
            /*Destroy(gameObject);
            RestartLevel.instance.Respawn();*/
        }
    }
}
