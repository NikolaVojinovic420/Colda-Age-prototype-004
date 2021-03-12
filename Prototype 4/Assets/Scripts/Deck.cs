using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]
    Transform tmpShuffleDeck;
    private void Awake()
    {
    }
    public void Shuffle()
    {
        Debug.Log($"{Time.time} {gameObject.name} shuffled.");
        while (transform.childCount > 0)
            gameObject.transform.GetChild(0).SetParent(tmpShuffleDeck);
        while(tmpShuffleDeck.childCount > 0)
            tmpShuffleDeck.GetChild(Random.Range(0, tmpShuffleDeck.childCount)).SetParent(gameObject.transform);           
    }
    public void Reshuffle(Deck from)
    {
        from.MigrateCards(gameObject);
        Shuffle();
    }
    public void MigrateCards(GameObject toDeck)
    {
        while (transform.childCount > 0)
            gameObject.transform.GetChild(0).SetParent(toDeck.transform);
    }
    public void Draw(GameObject toDeck) =>  gameObject.transform.GetChild(0).SetParent(toDeck.transform);
    
}
