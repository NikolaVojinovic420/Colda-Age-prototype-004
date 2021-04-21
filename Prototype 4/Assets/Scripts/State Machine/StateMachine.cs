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

    [SerializeField] private GameObject eventsObject;

    [SerializeField] private GameObject vigilantObject;
    [SerializeField] private GameObject engagedObject;

    [SerializeField] private GameObject vigilantAspectsObject;
    [SerializeField] private GameObject engagedAspectsObject;

    public Slider levelSlider;

    public EventDeck future;
    public EventDeck history;

    public UnitDisplay vigilant;
    public UnitDisplay engaged;

    public AspectDisplay vigilantAspectsDisplay;
    public AspectDisplay engagedAspectsDisplay;

    private State state;

    public GameObject winWindow;
    public GameObject lossWindow;

    public GameObject newConditionNReshuffle;

    void Awake()
    {
        state = new StartState(this);

        levelSlider.value = 0;

        future = futureObject.GetComponent<EventDeck>();
        history = historyObject.GetComponent<EventDeck>();

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
    public void AddEventsInHistory()
    {
        for (int i = 0; i < eventsObject.transform.childCount; i++)
        {
            AddSattelite(eventsObject.transform.GetChild(i).GetComponent<EventDeck>());
        }
    }
    void AddSattelite(EventDeck satelliteDeck)
    {
        if(satelliteDeck.IsEmpty())
        {
            satelliteDeck.gameObject.GetComponent<FillWithPrefabs>().InstantiateCardsInDeck(levelSlider.value * 100);
            history.AddEvent(satelliteDeck.Draw());
        }
        else
            history.AddEvent(satelliteDeck.Draw());
    }
    public void IncreaseExploration(float amount)
    {
        if (levelSlider.value >= 1)
            return;
        levelSlider.value += amount / 100;
    }

    public int ReturningDistance()
    {
        if (levelSlider.value >= 0.75)
            return 4;
        if (levelSlider.value >= 0.5)
            return 3;
        return 2;
    }
}