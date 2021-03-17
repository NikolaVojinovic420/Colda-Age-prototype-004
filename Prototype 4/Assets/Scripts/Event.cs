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

    public void Discard(EventDeck discardTo)
    {
        SetActive(false);
        Move(discardTo.gameObject);
        discardTo.AddEvent(this);
    }

    public void Draw(GameObject newOwner)
    {
        SetActive(true);
        Move(newOwner);
    }

    private void Move(GameObject destination)
    {
        gameObject.transform.SetParent(destination.transform);
        //GetComponent<Animate>().moveDestination = destination;
        Vector3 parentPos = destination.transform.position;
        //gameObject.transform.position = new Vector3(parentPos.x, parentPos.y, parentPos.z);
    }
}
