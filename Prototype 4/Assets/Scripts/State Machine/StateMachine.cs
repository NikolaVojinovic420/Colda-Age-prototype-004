using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject suppliesObject;

    [SerializeField] private GameObject futureObject;
    [SerializeField] private GameObject historyObject;

    public GameObject eventStageObject;

    [SerializeField] private GameObject eventsObject;

    [SerializeField] private GameObject vigilantObject;
    [SerializeField] private GameObject engagedObject;

    [SerializeField] private GameObject vigilantAspectsObject;
    [SerializeField] private GameObject engagedAspectsObject;
    [SerializeField] private GameObject supplyDisplay;

    [SerializeField] private GameObject blockedEventsObject;

    public Slider levelSlider;

    public Supplies supplies;

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

    public EventDeck blockedEvents;

    void Awake()
    {
        state = new StartState(this);

        supplies = suppliesObject.GetComponent<Supplies>();

        future = futureObject.GetComponent<EventDeck>();
        history = historyObject.GetComponent<EventDeck>();

        vigilant = vigilantObject.GetComponent<UnitDisplay>();
        engaged = engagedObject.GetComponent<UnitDisplay>();

        vigilantAspectsDisplay = vigilantAspectsObject.GetComponent<AspectDisplay>();
        engagedAspectsDisplay = engagedAspectsObject.GetComponent<AspectDisplay>();

        blockedEvents = blockedEventsObject.GetComponent<EventDeck>();
    }

    void Start()
    {
        StartCoroutine(state.Start());
    }
    void Update()
    {
        DisplaySupplies();
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
            FabricateEvent(eventsObject.transform.GetChild(i).GetComponent<EventDeck>());
    }
    void FabricateEvent(EventDeck deck)
    {
        if(deck.IsEmpty())
            deck.gameObject.GetComponent<Prefabrications>().InstantiateCardsInDeck(levelSlider.value, history, blockedEvents);

        if(!deck.IsEmpty())
            history.AddEvent(deck.Draw());
    }
    public void BlockPrefab(Event e) => blockedEvents.AddEvent(e);
    public void SetEventsRequirements()
    {
        for (int i = 0; i < eventsObject.transform.childCount; i++)
            eventsObject.transform.GetChild(i).GetComponent<Prefabrications>().RandomizePrefabedEventsRequirement();
    }
    public void IncreaseExploration(Aspect a)
    {
        if (levelSlider.value >= 100)
            return;
        int amount = a.a + a.p * 2 + a.l * 3;
        levelSlider.value += amount;
    }

    public int ReturningDistance()
    {
        if (levelSlider.value >= 80)
            return 4;
        if (levelSlider.value >= 50)
            return 3;
        return 2;
    }
    void DisplaySupplies() => supplyDisplay.GetComponent<Text>().text = $"SUPPLIES\n{supplies.GetValue()}";
}