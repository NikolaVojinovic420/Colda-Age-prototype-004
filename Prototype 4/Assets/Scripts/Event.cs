using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : Card
{
    [SerializeField]
    private string eventName;
    public string GetEventName() { return eventName; }

    [SerializeField]
    private string storyText;
    public string GetStoryText() { return storyText; }

    [SerializeField]
    private float exploreRequirement;
    private float saveExploreRequirement = 0;
    public float RequiredScale() => exploreRequirement;

    [SerializeField]
    private bool unique;
    public bool IsUnique() { return unique; }

    private void Awake()
    {
        animator = GetComponent<Animate>();
        animator.moveDestination = gameObject.transform.parent.position;
        //pull name from gameObject at instantiation
        eventName = gameObject.name.Split('(')[0];
    }
    public void StopInstantiation() //put expReq over 101 and save // call on prefab
    {
        saveExploreRequirement = exploreRequirement;
        exploreRequirement = 101;
    }
    public void ReturnInstantiation()
    {
        exploreRequirement = saveExploreRequirement;
    }
}
