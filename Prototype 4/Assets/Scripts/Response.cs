using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Response : MonoBehaviour
{
    private GameObject greenLight;
    private StateMachine stateMachine;
    private Card card;
    private Aspect cost;

    // Start is called before the first frame update
    void Awake()
    {
        stateMachine = FindObjectOfType<StateMachine>();
        cost = GetComponent<Aspect>();
        card = transform.parent.gameObject.GetComponent<Card>();
    }

    public void OnMouseDown()
    {
        if (card.IsActive() && currentEngagedCanPay())
            stateMachine.ResponseClicked(this);
    }

    private bool currentEngagedCanPay()
    {
        AspectDisplay engagedAspectDisplay = stateMachine.engagedAspectsDisplay;

        Debug.Log(engagedAspectDisplay._aspect.a+" >= "+cost.a+" && "+
            engagedAspectDisplay._aspect.p+" >= "+cost.p+" && "+
            engagedAspectDisplay._aspect.c+" >= "+cost.c);

        return engagedAspectDisplay._aspect.a >= cost.a &&
            engagedAspectDisplay._aspect.p >= cost.p &&
            engagedAspectDisplay._aspect.c >= cost.c;
    }
}
