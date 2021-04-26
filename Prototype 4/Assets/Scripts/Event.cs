using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : Card
{
    [SerializeField]
    private float exploreRequirement;
    [SerializeField]
    private bool startingEvent;
    public float RequiredScale() => exploreRequirement;
    public  bool hasInstanceLimit;
    public int InstanceLimit;
    [SerializeField]
    private bool irresponsive;
    public bool Defending() => irresponsive;

    private void Awake()
    {
        animator = GetComponent<Animate>();
        animator.moveDestination = gameObject.transform.parent.position;
        //pull name from gameObject at instantiation
        SetCardName(gameObject.name.Split('(')[0]);
    }
    public void SetNewRequirement(int requirement)
    {
        if(!startingEvent)
            exploreRequirement = requirement;     
    }
}
