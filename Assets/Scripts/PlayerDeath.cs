using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private int life = 5;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "mala")
        {
            life--;
            print(life);
            if(life == 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
   
}
