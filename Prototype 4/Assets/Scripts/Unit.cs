using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour , Card
{
    public Aspect aspect;

    //FIXME get rid of this field and solve in play state
    public bool engaged = false;

    private bool inDeck = true;

    private StateMachine stateMachine;

    void Awake()
    {
        stateMachine = FindObjectOfType<StateMachine>();
        aspect = GetComponent<Aspect>();
    }
    void OnMouseDown()
    {
        Debug.Log(this+" mouse click");
        if (inDeck)
            return;

        Debug.Log(this + " is not in the deck");

        stateMachine.UnitClicked(this);
    }

    public void Discard(UnitDeck discardTo)
    {
        inDeck = true;
        Move(discardTo.gameObject);
        discardTo.AddUnit(this);
    }

    public void Draw(GameObject newOwner)
    {
        inDeck = false;
        Move(newOwner);
    }
    public void Move(GameObject destination)
    {
        gameObject.transform.SetParent(destination.transform);
        GetComponent<Animate>().moveDestination = destination;
    }
}
