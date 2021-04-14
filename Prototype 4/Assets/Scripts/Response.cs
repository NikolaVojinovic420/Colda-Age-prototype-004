using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Response : MonoBehaviour
{
    private StateMachine stateMachine;
    private Card card;
    private Aspect cost;
    void Awake()
    {
        stateMachine = FindObjectOfType<StateMachine>();
        cost = GetComponent<Aspect>();
        card = transform.parent.gameObject.GetComponent<Card>();
    }
    public void OnMouseDown()
    {
        if (card.IsActive() && CurrentEngagedCanPay())
            stateMachine.ResponseClicked(this);
    }

    public bool CurrentEngagedCanPay()
    {
        AspectDisplay engagedAspectDisplay = stateMachine.engagedAspectsDisplay;

        //Debug.Log(engagedAspectDisplay._aspect.a+" >= "+cost.a+" && "+
        //    engagedAspectDisplay._aspect.p+" >= "+cost.p+" && "+
        //    engagedAspectDisplay._aspect.l+" >= "+cost.l);

        return engagedAspectDisplay._aspect.a >= cost.a &&
            engagedAspectDisplay._aspect.p >= cost.p &&
            engagedAspectDisplay._aspect.l >= cost.l;
    }
    public bool CurrentVigilantCanPay()
    {
        AspectDisplay vigilantAspectDisplay = stateMachine.vigilantAspectsDisplay;

        return vigilantAspectDisplay._aspect.a >= cost.a &&
            vigilantAspectDisplay._aspect.p >= cost.p &&
            vigilantAspectDisplay._aspect.l >= cost.l;
    }
    public bool IsActiveEvent() => card.IsActive();
}
