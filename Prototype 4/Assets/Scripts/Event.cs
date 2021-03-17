using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : Card
{
    private bool inDeck = true;

    private Animate animator;

    private void Awake()
    {
        animator = GetComponent<Animate>();
        animator.moveDestination = gameObject.transform.parent.position;
    }

    public void Discard(EventDeck discardTo)
    {
        inDeck = true;
        Move(discardTo.gameObject);
        discardTo.AddEvent(this);
    }

    public void Draw(GameObject newOwner)
    {
        inDeck = false;
        Move(newOwner);
    }

    private void Move(GameObject destination)
    {
        gameObject.transform.SetParent(destination.transform);
        //GetComponent<Animate>().moveDestination = destination;
        Vector3 parentPos = destination.transform.position;
        setPosition(parentPos);
        //gameObject.transform.position = new Vector3(parentPos.x, parentPos.y, parentPos.z);
    }
    public void setPosition(Vector3 pos)
    {
        animator.moveDestination = pos;
        //gameObject.transform.position = pos;
    }
}
