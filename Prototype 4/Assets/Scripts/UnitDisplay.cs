using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplay : MonoBehaviour
{
    public GameObject sumVigilantObject;
    public Aspect sumVigilant;
    public GameObject sumEngagedObject;
    public Aspect sumEngaged;
    public GameObject vigAspectUIObject;
    public GameObject engAspectUIObject;
    public GameObject preparing;
    public GameObject recovering;
    public GameObject vigilant;
    public GameObject engaged;
    public GameObject orchestratorObject;
    public Orchestrator orchestrator;

    // Start is called before the first frame update
    void Start()
    {
        orchestrator = orchestratorObject.GetComponent<Orchestrator>();
        sumVigilant = sumVigilantObject.GetComponent<Aspect>();
        sumEngaged = sumEngagedObject.GetComponent<Aspect>();
    }

    // Update is called once per frame
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
        sumVigilant.Copy(vigilant);
        sumEngaged.Copy(engaged);
    }
    void UpdateAspectsUI()
    {
        vigAspectUIObject.GetComponent<Text>().text = $"Vigilant:{sumVigilant.ReturnAspectString()}";
        engAspectUIObject.GetComponent<Text>().text = $"Engaged:{sumEngaged.ReturnAspectString()}";
    }
    public void SortCards(GameObject deck)//tmp solution
    {
        for (int i = 0; i < deck.transform.childCount; i++)
            deck.transform.GetChild(i).position = 
                new Vector2(deck.transform.position.x + i * (deck.transform.GetChild(i).localScale.x + 0.2f), deck.transform.position.y);
    }
}
