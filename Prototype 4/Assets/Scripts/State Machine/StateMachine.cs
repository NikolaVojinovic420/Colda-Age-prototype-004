using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject futureObject;
    [SerializeField] private GameObject historyObject;

    public GameObject eventStageObject;

    [SerializeField] private GameObject preparingObject;
    [SerializeField] private GameObject recoveringObject;

    [SerializeField] private GameObject vigilantObject;
    [SerializeField] private GameObject engagedObject;

    [SerializeField] private GameObject weatherObject;
    [SerializeField] private GameObject encounterObject;
    [SerializeField] private GameObject campDutiesObject;

    [SerializeField] private GameObject vigilantAspectsObject;
    [SerializeField] private GameObject engagedAspectsObject;

    public Slider levelSlider;

    public EventDeck future;
    public EventDeck history;

    public EventDeck weather;
    public EventDeck encounter;
    public EventDeck campDuties;

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

        weather = weatherObject.GetComponent<EventDeck>();
        encounter = encounterObject.GetComponent<EventDeck>();
        campDuties = campDutiesObject.GetComponent<EventDeck>();

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
    public void AddSatteliteEventsInHistory()
    {
        if(!weather.IsEmpty())
            history.AddEvent(weather.DrawRandom());
        if (!encounter.IsEmpty())
            history.AddEvent(encounter.DrawRandom());
        if (!campDuties.IsEmpty())
            history.AddEvent(campDuties.DrawRandom());
    }
}