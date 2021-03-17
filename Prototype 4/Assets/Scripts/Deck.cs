using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck<C> where C : Card
{
    private readonly List<C> Cards = new List<C>();

    public void Push(C card)
    {
        Cards.Add(card);
    }
    public C Pop()
    {
        int index = Cards.Count - 1;
        C popped = Cards[index];
        Cards.RemoveAt(index);
        return popped;
    }

    public bool IsEmpty()
    {
        return Cards.Count == 0;
    }

    public void Shuffle()
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            C tmp = Cards[i];
            int randomIndex = Random.Range(i, Cards.Count);
            Cards[i] = Cards[randomIndex];
            Cards[randomIndex] = tmp;
        }
    }
}
