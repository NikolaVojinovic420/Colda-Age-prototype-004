using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDeck : MonoBehaviour
{
    private readonly Deck<Unit> deck = new Deck<Unit>();

    public void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject childObject = transform.GetChild(i).gameObject;
            Unit child = childObject.GetComponent<Unit>();
            deck.Push(child);
        }
    }

    public Unit Draw(UnitDisplay to)
    {
        Unit u = deck.Pop();
        u.Draw(to);
        return u;
    }

    public void AddUnit(Unit u)
    {
        deck.Push(u);
    }

    public bool IsEmpty()
    {
        return deck.IsEmpty();
    }

    public void Reshuffle(UnitDeck from)
    {
        while(!from.IsEmpty())
        {
            Unit u = from.deck.Pop();
            u.Move(gameObject);
            AddUnit(u);
        }
        deck.Shuffle();
    }
}
