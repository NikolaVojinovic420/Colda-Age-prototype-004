using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Card
{
    private Aspect aspect;
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

    public void addAspectTo(AspectMap am) { am.Add(aspect); }
    public string AspectsAsString() { return aspect.ReturnAspectString(); }
}
