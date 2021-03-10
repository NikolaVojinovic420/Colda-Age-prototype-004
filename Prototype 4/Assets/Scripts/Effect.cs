using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public bool win;
    public bool loss;
    public bool exhaustable;
    public int draw;
    public GameObject insertEvent;

    public void Execute(EventStage eventStage)
    {
        if (loss) 
            eventStage.lossWindow.SetActive(true);
        if (win)
            eventStage.winWindow.SetActive(true);
        if (exhaustable)
            Destroy(eventStage.activeEventStage.transform.GetChild(0).gameObject); //Exhaust
        else //Discard
        {
            eventStage.activeEventStage.transform.GetChild(0).position = eventStage.history.transform.position;
            eventStage.activeEventStage.transform.GetChild(0).SetParent(eventStage.history.transform);
        }
        if (insertEvent != null)
            Instantiate(insertEvent, eventStage.history.transform);
        eventStage.orchestratorObject.GetComponent<Orchestrator>().CallOrchestrator(this);
    }
}
