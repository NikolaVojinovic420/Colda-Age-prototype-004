using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck2 : MonoBehaviour, CardContainer
{
    private readonly List<Card> cards = new List<Card>();

    public void add(Card card)
    {
        cards.Add(card);
    }
    public Card removeFromTop()
    {
        if (IsEmpty())
            throw new System.Exception("Trying to remove a card from an empty deck");

        int index = cards.Count - 1;
        Card drawn = cards[index];
        cards.RemoveAt(index);
        return drawn;
    }

    public bool IsEmpty()
    {
        return cards.Count == 0;
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card tmp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = tmp;
        }
    }

    public Vector3 nextCardPosition()
    {
        Vector3 parentPosition = gameObject.transform.position;
        Vector3 position = new Vector3(parentPosition.x, parentPosition.y, parentPosition.z);
        return position;
    }
}
