using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    State _state;
    public GameObject vigilant;
    public GameObject engaged;
    public GameObject preparingObject;
    public GameObject recoveringObject;
    public Deck<Unit> preparing;
    public Deck<Unit> recovering;
    public GameObject history;

    void Awake()
    {
        Debug.Log("awake statemachine");
        _state = new StartState(this);
        preparing = preparingObject.GetComponent<Deck<Unit>>();
        recovering = recoveringObject.GetComponent<Deck<Unit>>();
        StartCoroutine(_state.Start());
    }
    public void SetState(State state)
    {
        StartCoroutine(_state.End());
        _state = state;
        Debug.Log($"{_state} started");
        StartCoroutine(_state.Start());
    }
    public void OnResponse(EventResponse eventResponse) => _state.OnEventResponse(eventResponse);
    public void Engage(Unit unit) => _state.Engage(unit);
    public void Disengage(Unit unit) => _state.Disengage(unit);
    public void DrawUnit()
    {
        Unit drawnUnit = preparing.Draw();
        drawnUnit.isVigilant = true;
        drawnUnit.gameObject.transform.SetParent(vigilant.transform);
    }
}


