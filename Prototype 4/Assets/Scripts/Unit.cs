using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Card
{
    public Aspect aspect;
    //private Animate animator;

    //FIXME get rid of this field and solve in play state
    public bool engaged = false;

    private StateMachine stateMachine;

    void Awake()
    {
        stateMachine = FindObjectOfType<StateMachine>();
        aspect = GetComponent<Aspect>();
        animator = GetComponent<Animate>();
        animator.moveDestination = gameObject.transform.parent.position;
    }
    void OnMouseDown()
    {
        if (!IsActive())
            return;

        stateMachine.UnitClicked(this);
    }

    public void Discard(UnitDeck discardTo)
    {
        SetActive(false);
        Move(discardTo.gameObject);
        discardTo.AddUnit(this);
    }

    public void Draw(UnitDisplay toDisplay)
    {
        SetActive(true);
        Move(toDisplay.gameObject);
        toDisplay.Add(this);
    }
    public void Move(GameObject destination)
    {
        gameObject.transform.SetParent(destination.transform);
        //GetComponent<Animate>().moveDestination = destination;
        Vector3 parentPos = destination.transform.position;
        SetPosition(parentPos);
        //gameObject.transform.position = new Vector3(parentPos.x, parentPos.y, parentPos.z);
    }

    public void SetPosition(Vector3 pos)
    {
        animator.moveDestination = pos;
        //gameObject.transform.position = pos;
    }
}
