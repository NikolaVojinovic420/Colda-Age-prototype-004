using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDeck : MonoBehaviour
{
    private Deck<Unit> deck = new Deck<Unit>();

    public void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject childObject = transform.GetChild(i).gameObject;
            Unit child = childObject.GetComponent<Unit>();
            deck.push(child);
        }
    }

    public Unit draw()
    {
        return deck.Pop();
    }

    public bool isEmpty()
    {
        return deck.IsEmpty();
    }

    public void reshuffle(UnitDeck from)
    {
        while(!from.isEmpty())
        {
            Unit u = from.draw();
            deck.push(u);
        }
        deck.Shuffle();
    }
}
