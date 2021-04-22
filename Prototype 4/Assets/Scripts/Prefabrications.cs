using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabrications : MonoBehaviour
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
    public void InstantiateCardsInDeck(float requiredValue, EventDeck history)
    {
        foreach (GameObject item in cards)
        {
            Event e = item.GetComponent<Event>();
            if (requiredValue >= e.RequiredScale() && !history.Contains(item.name))
                Instantiate(item, transform);        
        }           
        deck.FillEventDeck();
        deck.SelfShuffle();
    }
    public void RandomizePrefabedEventsRequirement()
    {
        foreach (GameObject item in cards)
            item.GetComponent<Event>().SetNewRequirement(Random.Range(0, 100));
    }
}
