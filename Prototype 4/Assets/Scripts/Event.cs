using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : Card
{
    private void Awake()
    {
        animator = GetComponent<Animate>();
        animator.moveDestination = gameObject.transform.parent.position;
    }
}
