using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Card
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
        if (inDeck)
            return;

        stateMachine.UnitClicked(this);
    }

    public void Discard(UnitDeck discardTo)
    {
        inDeck = true;
        Move(discardTo.gameObject);
        discardTo.AddUnit(this);
    }

    public void Draw(UnitDisplay toDisplay)
    {
        inDeck = false;
        Move(toDisplay.gameObject);
        toDisplay.add(this);
    }
    public void Move(GameObject destination)
    {
        gameObject.transform.SetParent(destination.transform);
        //GetComponent<Animate>().moveDestination = destination;
        Vector3 parentPos = destination.transform.position;
        gameObject.transform.position = new Vector3(parentPos.x, parentPos.y, parentPos.z);
    }

    public void setPosition(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }
}
