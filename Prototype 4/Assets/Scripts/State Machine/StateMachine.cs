using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public GameObject futureObject;
    public GameObject historyObject;

    public GameObject eventStage;

    public GameObject preparingObject;
    public GameObject recoveringObject;

    public GameObject vigilantObject;
    public GameObject engagedObject;

    public UnitDeck preparing;
    public UnitDeck recovering;

    public EventDeck future;
    public EventDeck history;

    private State state;

    void Awake()
    {
        Debug.Log("awake statemachine");
        state = new StartState(this);

        preparing = preparingObject.GetComponent<UnitDeck>();
        recovering = recoveringObject.GetComponent<UnitDeck>();

        future = futureObject.GetComponent<EventDeck>();
        history = historyObject.GetComponent<EventDeck>();
    }

    void Start()
    {
        StartCoroutine(state.Start());
    }

    public void SetState(State state)
    {
        StartCoroutine(state.End());
        this.state = state;
        Debug.Log($"{state} started");
        StartCoroutine(state.Start());
    }
    public void OnResponse(EventResponse eventResponse)
    {
        Debug.Log(state + " == null " + (state == null));
        StartCoroutine(state.OnEventResponse(eventResponse));
    }
    public void Engage(Unit unit) => state.Engage(unit);
    public void Disengage(Unit unit) => state.Disengage(unit);
    public void DrawUnit()
    {
        Unit drawnUnit = preparing.draw();
        drawnUnit.isVigilant = true;
        drawnUnit.gameObject.transform.SetParent(vigilantObject.transform);
    }
}


