using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    //The character's animator
    public Animator anim;
    //The character's reach target
    public Transform reachTarget;

    //What object are we trying to pick up?
    public GameObject pickupObject;
    //What transform to we want to parent it to? 
    public Transform hand;
    //What position and rotation do we want it set to after we pick it up?
    public Transform newObjectPosRot;

    public void PickUp()
    {
        pickupObject.transform.SetParent(hand);
        pickupObject.transform.localPosition = newObjectPosRot.localPosition;
        pickupObject.transform.localRotation = newObjectPosRot.localRotation;
    }

    public void PauseAnimation()
    {
        anim.speed = 0;
    }
}
