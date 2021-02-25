using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public Transform tmpShuffleDeck;

    public void Reshuffle(GameObject deck)
    {
        for (int i = 0; i < deck.transform.childCount; i++)
            deck.transform.GetChild(0).SetParent(tmpShuffleDeck);
        int count = tmpShuffleDeck.childCount;
        for (int i = 0; i < count; i++)
            tmpShuffleDeck.GetChild(Random.Range(0, tmpShuffleDeck.childCount)).SetParent(deck.transform);
    }
    public void MigrateCards(GameObject fromDeck, GameObject toDeck)
    {
        for (int i = 0; i < fromDeck.transform.childCount; i++)
            fromDeck.transform.GetChild(0).SetParent(toDeck.transform);
    }
    public void DrawFirst(GameObject fromDeck, GameObject toDeck) => fromDeck.transform.GetChild(0).SetParent(toDeck.transform);

}
