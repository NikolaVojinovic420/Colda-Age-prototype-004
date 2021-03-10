﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State _state;
    public GameObject vigilant;
    public GameObject engaged;

    void  Awake()
    {
        Debug.Log("awake statemachine");
        _state = new StartState(this);
    }
    public void SetState(State state)
    {
        StartCoroutine(_state.End());
        _state = state;
        StartCoroutine(_state.Start());
    }
    public void OnResponse(EventResponse eventResponse) => _state.OnEventResponse(eventResponse);
    public void Engage(Unit unit) => _state.Engage(unit);
    public void Disengage(Unit unit) => _state.Disengage(unit);
}