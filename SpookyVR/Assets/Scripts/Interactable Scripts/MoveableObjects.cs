using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjects : InteractableObject
{
    public override void Interact()
    {
        PlayerBehavior player = FindObjectOfType<PlayerBehavior>();
        Rigidbody rb = GetComponent<Rigidbody>();
        Collider thisCollider = GetComponent<Collider>();

        // If the player does not have an object held, hold this object.
        if(!player.GetHoldingStatus())
        {
            player.SetHoldingStatus(true);
            gameObject.transform.position = player.GetHand().transform.position;
            gameObject.transform.parent = Camera.main.transform;
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
            rb.isKinematic = true;
            Physics.IgnoreCollision(thisCollider, player.GetComponent<Collider>(), true);
        }
        // If the player is holding an object, drop the object.
        else if(player.GetHoldingStatus())
        {
            player.SetHoldingStatus(false);
            gameObject.transform.parent = null;
            rb.freezeRotation = false;
            rb.isKinematic = false;
            Physics.IgnoreCollision(thisCollider, player.GetComponent<Collider>(), false);
        }
    }
}
