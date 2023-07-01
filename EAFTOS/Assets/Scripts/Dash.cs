using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Generic Ability", fileName = "New Generic Ability")]
public class Dash : GenericAbility
{
    public float dashForce;

    public override void Ability(Vector2 playerPosition, Vector2 playerFacingDirection,
        Animator playerAnimator = null, Rigidbody2D playerRigidbody = null)
    {
        if(playerStamina.initialValue >= staminaCost)
        {
            playerStamina.initialValue -= staminaCost;

        }
        else
        {
            return;
        }
        if(playerRigidbody)
        {
            Vector3 dashVector = playerRigidbody.transform.position +
                (Vector3)playerFacingDirection.normalized * dashForce;
            playerRigidbody.MovePosition(dashVector * duration);
        }
    }

}
