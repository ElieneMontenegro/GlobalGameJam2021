using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableManager : MonoBehaviour
{
    [SerializeField] GameObject startCollider, endCollider;

    [SerializeField] float ClimbingSpeed = 0.5f;

    //At the Start of the Game send to the Colliders the start and end point of the Climbable
    public void SetUpPlayer(GameObject Player, bool isDown)
    {
        PlayerController playerMovement = Player.GetComponent<PlayerController>();
        playerMovement.SetClimbableData(true, startCollider.transform.position, endCollider.transform.position, isDown, ClimbingSpeed);
    }
    public void PlayerOffClimbable(GameObject Player)
    {
        PlayerController playerMovement = Player.GetComponent<PlayerController>();
        playerMovement.OffClimbable();
    }
}
