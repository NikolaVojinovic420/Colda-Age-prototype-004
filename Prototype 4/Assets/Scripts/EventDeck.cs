using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDeck : MonoBehaviour
{
    private Deck<Event> deck = new Deck<Event>();

    public void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject childObject = transform.GetChild(i).gameObject;
            Event child = childObject.GetComponent<Event>();
            deck.push(child);
        }
    }

    public Event Draw()
    {
        Debug.Log($"event deck "+deck.IsEmpty());
        return deck.Pop();
    }

    public bool IsEmpty()
    {
        return deck.IsEmpty();
    }

    public void Reshuffle(EventDeck from)
    {
        while (!from.IsEmpty())
        {
            Event e = from.Draw();
            deck.push(e);
        }
        deck.Shuffle();
    }
}
