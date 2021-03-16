using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour, Card
{
    private bool inDeck = true;

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
        //gameObject.transform.position = new Vector3(parentPos.x, parentPos.y, parentPos.z);
    }
}
