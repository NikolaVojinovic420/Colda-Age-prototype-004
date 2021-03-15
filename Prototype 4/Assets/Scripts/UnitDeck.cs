using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDeck : MonoBehaviour
{
    private Deck<Unit> deck = new Deck<Unit>();

    void Awake()
    {
        // find all unit children of the game object and put them into the deck object
    }

    public Unit draw()
    {
        return deck.pop();
    }

    public bool isEmpty()
    {
        return deck.isEmpty();
    }

    public void reshuffle(UnitDeck from)
    {
        while(!from.isEmpty())
        {
            Unit u = from.draw();
            deck.push(u);
        }
        deck.shuffle();
    }
}
