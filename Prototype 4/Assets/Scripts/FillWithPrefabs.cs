using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillWithPrefabs : MonoBehaviour
{
    Object[] cards;
    EventDeck deck;
    [SerializeField]
    string path;    //"Prrefabs/Cards/Events/Weather...."

    void Awake()
    {
        deck = gameObject.GetComponent<EventDeck>();
        GetAllObjects();
    }
    void GetAllObjects()
    {
        cards = Resources.LoadAll(path, typeof(GameObject));
    }
    public void InstantiateCardsInDeck()
    {
        foreach (GameObject item in cards)
            Instantiate(item, gameObject.transform);

        deck.FillEventDeck();
        deck.SelfShuffle();
    }
}
