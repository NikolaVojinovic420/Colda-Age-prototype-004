using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDeck : MonoBehaviour
{
    private Deck<Event> deck = new Deck<Event>();

    void Awake()
    {
        // find all unit children of the game object and put them into the deck object
    }

    public Event draw()
    {
        return deck.pop();
    }

    public bool isEmpty()
    {
        return deck.isEmpty();
    }

    public void reshuffle(EventDeck from)
    {
        while (!from.isEmpty())
        {
            Event e = from.draw();
            deck.push(e);
        }
        deck.shuffle();
    }
}
