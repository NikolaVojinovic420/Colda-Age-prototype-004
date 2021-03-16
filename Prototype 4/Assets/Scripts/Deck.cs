using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck<C> where C : Card
{
    private List<C> cards = new List<C>();
    
    public void push(C card)
    {
        cards.Add(card);
    }
    public C Pop()
    {
        int index = cards.Count - 1;
        C popped = cards[index];
        cards.RemoveAt(index);
        return popped;
    }

    public bool IsEmpty()
    {
        return cards.Count == 0;
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            C tmp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = tmp;
        }
    }
}
