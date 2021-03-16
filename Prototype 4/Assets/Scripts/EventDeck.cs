using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDeck : MonoBehaviour
{
    private readonly Deck<Event> deck = new Deck<Event>();

    public void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject childObject = transform.GetChild(i).gameObject;
            Event child = childObject.GetComponent<Event>();
            deck.push(child);
        }
    }

    public Event Draw(GameObject newOwner)
    {
        Debug.Log($"event deck is empty="+deck.IsEmpty());
        Event e = deck.Pop();
        e.Draw(newOwner);
        return e;
    }

    public void AddEvent(Event e)
    {
        deck.push(e);
    }

    public bool IsEmpty()
    {
        return deck.IsEmpty();
    }

    public void Reshuffle(EventDeck from)
    {
        while (!from.IsEmpty())
        {
            Event e = from.Draw(gameObject);
            deck.push(e);
        }
        deck.Shuffle();
    }
}
