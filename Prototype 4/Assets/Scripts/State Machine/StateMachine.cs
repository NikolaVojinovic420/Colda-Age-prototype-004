using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject futureObject;
    [SerializeField] private GameObject historyObject;

    public GameObject eventStageObject;

    [SerializeField] private GameObject preparingObject;
    [SerializeField] private GameObject recoveringObject;

    [SerializeField] private GameObject vigilantObject;
    [SerializeField] private GameObject engagedObject;

    public EventDeck future;
    public EventDeck history;

    public UnitDeck preparing;
    public UnitDeck recovering;

    public UnitDisplay vigilant;
    public UnitDisplay engaged;

    private State state;

    void Awake()
    {
        state = new StartState(this);

        future = futureObject.GetComponent<EventDeck>();
        history = historyObject.GetComponent<EventDeck>();

        preparing = preparingObject.GetComponent<UnitDeck>();
        recovering = recoveringObject.GetComponent<UnitDeck>();

        vigilant = vigilantObject.GetComponent<UnitDisplay>();
        engaged = engagedObject.GetComponent<UnitDisplay>();
    }

    void Start()
    {
        StartCoroutine(state.Start());
    }

    public void SetState(State state)
    {
        StartCoroutine(state.End());
        this.state = state;
        Debug.Log("State change to -> "+state);
        StartCoroutine(state.Start());
    }
    public void ResponseClicked(EventResponse eventResponse)
    {
        Debug.Log(state + " == null " + (state == null));
        StartCoroutine(state.ResponseClicked(eventResponse));
    }

    public void UnitClicked(Unit unit)
    {
        Debug.Log("mehtod call -> UnitClicked in StateMachine. Current state is " + state);
        StartCoroutine(state.UnitClicked(unit));
    }

    public void ReshuffleIfNeededAndDrawUnit()
    {
        if (preparing.IsEmpty())
            preparing.Reshuffle(recovering);
        preparing.Draw(vigilant);
    }
}