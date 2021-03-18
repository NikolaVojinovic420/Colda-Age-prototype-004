using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Card
{
    public Aspect aspect;

    //FIXME get rid of this field and solve in play state
    public bool engaged = false;

    private StateMachine stateMachine;

    void Awake()
    {
        Debug.Log("awake unit");
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
}
