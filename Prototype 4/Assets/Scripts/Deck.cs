using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Transform tmpShuffleDeck;
    private void Awake()
    {
        Reshuffle();
    }
    public void Reshuffle()
    {
        Debug.Log($"{Time.time} {gameObject.name} reshuffled.");
        int count = gameObject.transform.childCount;
        for (int i = 0; i < count; i++)
            gameObject.transform.GetChild(0).SetParent(tmpShuffleDeck);
        for (int i = 0; i < count; i++)
            tmpShuffleDeck.GetChild(Random.Range(0, tmpShuffleDeck.childCount)).SetParent(gameObject.transform);           
    }
    public void MigrateCards(GameObject toDeck)
    {
        int count = gameObject.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            gameObject.transform.GetChild(0).transform.position = toDeck.transform.position;
            gameObject.transform.GetChild(0).SetParent(toDeck.transform);
        }
            
    }
    public void DrawFirst(GameObject toDeck)
    {
        gameObject.transform.GetChild(0).position = toDeck.transform.position;
        gameObject.transform.GetChild(0).SetParent(toDeck.transform);
    }
    

}
