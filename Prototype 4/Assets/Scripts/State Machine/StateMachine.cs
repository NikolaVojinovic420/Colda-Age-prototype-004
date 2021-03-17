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

    [SerializeField] private GameObject vigilantAspectsObject;
    [SerializeField] private GameObject engagedAspectsObject;

    public EventDeck future;
    public EventDeck history;

    public UnitDeck preparing;
    public UnitDeck recovering;

    public UnitDisplay vigilant;
    public UnitDisplay engaged;

    public AspectDisplay vigilantAspectsDisplay;
    public AspectDisplay engagedAspectsDisplay;

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

        vigilantAspectsDisplay = vigilantAspectsObject.GetComponent<AspectDisplay>();
        engagedAspectsDisplay = engagedAspectsObject.GetComponent<AspectDisplay>();
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
    public void ResponseClicked(Response eventResponse)
    {
        StartCoroutine(state.ResponseClicked(eventResponse));
    }

    public void UnitClicked(Unit unit)
    {
        StartCoroutine(state.UnitClicked(unit));
    }

    public void ReshuffleIfNeededAndDrawUnit()
    {
        if (preparing.IsEmpty())
            preparing.Reshuffle(recovering);
        preparing.Draw(vigilant);
    }
}