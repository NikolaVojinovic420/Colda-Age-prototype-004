using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck <T>: MonoBehaviour where T : Card
{
    List<T> cards;
    [SerializeField]
    Transform tmpShuffleDeck;
    private void Awake()
    {
        cards = new List<T>();
        for (int i = 0; i < transform.childCount; i++)
            cards.Add(transform.GetChild(i).gameObject.GetComponent<T>());
    }
    public void Shuffle()
    {
        Debug.Log($"{Time.time} {gameObject.name} shuffled.");
        while (transform.childCount > 0)
            gameObject.transform.GetChild(0).SetParent(tmpShuffleDeck);
        while(tmpShuffleDeck.childCount > 0)
            tmpShuffleDeck.GetChild(Random.Range(0, tmpShuffleDeck.childCount)).SetParent(gameObject.transform);           
    }
    public void Reshuffle(Deck<T> from)
    {
        from.MigrateCards(gameObject);
        Shuffle();
    }
    public void MigrateCards(GameObject toDeck)
    {
        while (transform.childCount > 0)
            gameObject.transform.GetChild(0).SetParent(toDeck.transform);
    }
    public T  Draw()
    {
        T t = cards[cards.Count-1];
        cards.RemoveAt(cards.Count - 1);
        return t;
    }
    
}
