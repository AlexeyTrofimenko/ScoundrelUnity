using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerController : MonoBehaviour
{
    public Animator bodyAnimator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ShipStats.inDodge)
        {
            DodgeGadgetActivate();
        }
    }

    void DodgeGadgetActivate()
    {
        bodyAnimator.SetTrigger("Dodge");
        ShipStats.inDodge = false;
    }
}