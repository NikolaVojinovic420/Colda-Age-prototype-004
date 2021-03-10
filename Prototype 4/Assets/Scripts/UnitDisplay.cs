using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplay : MonoBehaviour
{
    public GameObject vigAspectUIObject;
    public GameObject engAspectUIObject;
    public GameObject vigilant;
    public GameObject engaged;

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
        vigAspectUIObject.GetComponent<Aspect>().Copy(vigilant);
        engAspectUIObject.GetComponent<Aspect>().Copy(engaged);
    }
    void UpdateAspectsUI()
    {
        vigAspectUIObject.GetComponent<Text>().text = $"Vigilant:{vigAspectUIObject.GetComponent<Aspect>().ReturnAspectString()}";
        engAspectUIObject.GetComponent<Text>().text = $"Engaged:{engAspectUIObject.GetComponent<Aspect>().ReturnAspectString()}";
    }
    public void SortCards(GameObject deck)//tmp solution
    {
        for (int i = 0; i < deck.transform.childCount; i++)
            deck.transform.GetChild(i).position = 
                new Vector2(deck.transform.position.x + i * (deck.transform.GetChild(i).localScale.x + 0.2f), deck.transform.position.y);
    }
}
