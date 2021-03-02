using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStage : MonoBehaviour
{
    public GameObject poofArea;
    public GameObject activeEventStage;
    public GameObject future;
    public GameObject history;
    public GameObject winWindow;
    public GameObject lossWindow;
    public GameObject unitDisplayObject;
    public UnitDisplay unitDisplay;
    public GameObject orchestratorObject;
    public Orchestrator orchestrator;
    // Start is called before the first frame update
    void Start()
    {
        orchestrator = orchestratorObject.GetComponent<Orchestrator>();
        unitDisplay = unitDisplayObject.GetComponent<UnitDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Exhaust() => Destroy(activeEventStage.transform.GetChild(0).gameObject);
    void Discard()
    {
        activeEventStage.transform.GetChild(0).position = history.transform.position;
        activeEventStage.transform.GetChild(0).SetParent(history.transform);        
    }
    public void ExecuteEndEvent(Effect effect)
    {
        if(effect.loss)
            lossWindow.SetActive(true);

        if (effect.win)
            winWindow.SetActive(true);

        if (effect.exhaustable)
            Exhaust();
        else Discard();

        if (effect.insertEvent != null)
        {
            effect.insertEvent.transform.SetParent(history.transform);
            Debug.Log($"{Time.time} {effect.insertEvent.name} has been inserted into History");
        }
            

        orchestrator.CallOrchestrator(effect);

        //or finish everything here
        //orchestrator.drawer.MigrateCards(unitDisplay.engaged, unitDisplay.recovering);

        //for (int i = 0; i < effect.draw; i++)
        //    orchestrator.drawer.DrawFirst(unitDisplay.preparing, unitDisplay.vigilant);
    }
}

