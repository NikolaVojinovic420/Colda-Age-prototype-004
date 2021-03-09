﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State _state;

    void Awake()
    {
        _state = new StartState(this);
    }
    public void SetState(State state)
    {
        _state = state;
        StartCoroutine(_state.Start());
    }
    internal void OnResponse(EventResponse eventResponse)
    {
        if (_state is PlayState)
            (_state as PlayState).OnResponse(eventResponse);
    }
}
