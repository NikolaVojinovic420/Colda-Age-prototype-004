using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Card
{
    private Aspect aspect;
    private StateMachine stateMachine;

    public int timeToRecovery = 0;
    public void Fatique(int strain) { timeToRecovery += strain; }
    public void Recover(int betterment)
    {
        if (timeToRecovery > 0)
            timeToRecovery -= betterment;
    }
    public override bool IsActive() { return timeToRecovery == 0; }

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

    public void AddAspectTo(AspectMap am) { am.Add(aspect); }
    public string AspectsAsString() { return aspect.ReturnAspectString(); }
}
