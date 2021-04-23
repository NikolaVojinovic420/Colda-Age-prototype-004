using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : Card
{
    [SerializeField]
    private float exploreRequirement;
    private float saveExploreRequirement = 0;
    [SerializeField]
    private bool startingEvent;
    public float RequiredScale() => exploreRequirement;
    [SerializeField]
    private bool hasInstanceLimit;
    public bool CheckInstanceLimit() => hasInstanceLimit;
    public int InstanceLimit;
    [SerializeField]
    private bool defensingevent;
    public bool Defending() => defensingevent;

    private void Awake()
    {
        animator = GetComponent<Animate>();
        animator.moveDestination = gameObject.transform.parent.position;
        //pull name from gameObject at instantiation
        SetCardName(gameObject.name.Split('(')[0]);
    }
    public void StopInstantiation() //put expReq over 101 and save // call on prefab
    {
        saveExploreRequirement = exploreRequirement;
        exploreRequirement = 101;
    }
    public void ReturnInstantiation() => exploreRequirement = saveExploreRequirement;
    public void SetNewRequirement(float requirement)
    {
        if(!startingEvent)
            exploreRequirement = requirement;
    }
}
