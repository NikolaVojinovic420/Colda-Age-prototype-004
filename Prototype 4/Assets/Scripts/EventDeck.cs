﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDeck : MonoBehaviour
{
    private readonly Deck<Event> deck = new Deck<Event>();
    public void Awake()
    {
        FillEventDeck();
    }

    public Event Draw() 
    {
        Event e = deck.Pop();
        return e;
    }
    public void AddEvent(Event e)
    {
        deck.Push(e);
        e.Transfer(transform, false);
    }

    public bool IsEmpty()
    {
        return deck.IsEmpty();
    }
    public void SelfShuffle() => deck.Shuffle();
    public void Reshuffle(EventDeck from)
    {
        while (!from.IsEmpty())
        {
            Event e = from.Draw();
            e.Transfer(transform, false);
            deck.Push(e);
        }
        deck.Shuffle();
    }
    public bool Contains(string cardName)
    {
        return deck.Contains(cardName);
    }
    public Event RemoveWhereName(string cardName)
    {
        return deck.RemoveWithName(cardName);
    }
    public void FillEventDeck()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject childObject = transform.GetChild(i).gameObject;
            Event child = childObject.GetComponent<Event>();
            deck.Push(child);
        }
    }
}
