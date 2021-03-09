using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplay : MonoBehaviour
{
    //UI display vig and eng
    public GameObject sumVigilantObject;
    public GameObject sumEngagedObject;
    public GameObject vigAspectUIObject;
    public GameObject engAspectUIObject;
    //Decks
    public GameObject preparing;
    public GameObject recovering;
    public GameObject vigilant;
    public GameObject engaged;

    public GameObject orchestrator;

    void FixedUpdate()
    {
        RefreshAspects();
        SortCards(vigilant);
        SortCards(engaged);
    }
    void RefreshAspects()
    {
            CopyAspects();
            UpdateAspectsUI();
    }
    public void CopyAspects()
    {
        sumVigilantObject.GetComponent<Aspect>().Copy(vigilant);
        sumEngagedObject.GetComponent<Aspect>().Copy(engaged);
    }
    void UpdateAspectsUI()
    {
        vigAspectUIObject.GetComponent<Text>().text = $"Vigilant:{sumVigilantObject.GetComponent<Aspect>().ReturnAspectString()}";
        engAspectUIObject.GetComponent<Text>().text = $"Engaged:{sumEngagedObject.GetComponent<Aspect>().ReturnAspectString()}";
    }
    public void SortCards(GameObject deck)//tmp solution
    {
        for (int i = 0; i < deck.transform.childCount; i++)
            deck.transform.GetChild(i).position = 
                new Vector2(deck.transform.position.x + i * (deck.transform.GetChild(i).localScale.x + 0.2f), deck.transform.position.y);
    }
}
