using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MalinhaPoints : MonoBehaviour
{

    public static int pontos = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pontos++;
            if(pontos == 5)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

}
