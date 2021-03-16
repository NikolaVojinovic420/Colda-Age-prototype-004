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
    public void ResponseClicked(EventResponse eventResponse)
    {
        Debug.Log(state + " == null " + (state == null));
        StartCoroutine(state.ResponseClicked(eventResponse));
    }

    public void UnitClicked(Unit unit)
    {
        Debug.Log("engage unit in " + state);
        StartCoroutine(state.UnitClicked(unit));
    }

    public void DrawUnit()
    {
        preparing.Draw(vigilantObject);
    }

    public void ReshuffleUnits()
    {
        preparing.Reshuffle(recovering);
    }
}


