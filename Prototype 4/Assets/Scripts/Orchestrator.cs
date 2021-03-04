using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orchestrator : MonoBehaviour
{
    public GameObject eventStageObject;
    public EventStage eventStage;
    public GameObject unitDisplayObject;
    public UnitDisplay unitDisplay;

    //block
    bool drawEventFree = false;
    public bool canEngageDisengage = true;
    bool responded = false;
    bool canMigrateEngaged = false;
    bool askForReshuffle = false;
    bool canDraw = false;
    int drawTimes = 0;
    // Start is called before the first frame update
    void Start()
    {
        eventStage = eventStageObject.GetComponent<EventStage>();
        unitDisplay = unitDisplayObject.GetComponent<UnitDisplay>();

        DrawEvent();
        for (int i = 0; i < 5; i++)
            unitDisplay.preparing.GetComponent<Deck>().DrawFirst(unitDisplay.vigilant);
    }

    void FixedUpdate()
    {
        Controller();
    }
    void DrawEvent()
    {
        if (eventStage.activeEventStage.transform.childCount <= 0)
            eventStage.future.GetComponent<Deck>().DrawFirst(eventStage.activeEventStage);
    }
    void Controller()
    {
        //draw event
        if ( drawEventFree)
        {
            DrawEvent();
            Debug.Log($"{Time.time} Orchestrator drawed an event");
        }
        //unit engage and disengage
        if(!canEngageDisengage)
        {
            Debug.Log("Orchestrator aproves Engage/Disengage method");
            canEngageDisengage = true;
            responded = true;
        }

        //Responding to event
        if (responded)
        {
            Debug.Log($"{Time.time} Orchestrator accept respond and continues, u can migrate Engaged");
            canMigrateEngaged = true;
            responded = false;
        }
        //send engaged into recovering
        if ( canMigrateEngaged)
        {
            Debug.Log($"{Time.time} Orchestrator moving migrating Engaged and ask for reshuffle");
            unitDisplay.engaged.GetComponent<Deck>().MigrateCards(unitDisplay.recovering);
            Debug.Log($"{Time.time} Orchestrator finished migrating Engaged");
            canMigrateEngaged = false;
            askForReshuffle = true;
        }
        //controll reshuffle
        if ( askForReshuffle)
        {
            Debug.Log($"{Time.time} Orchestrator checking for reshuffle");
            ReshuffleFutureAndPreparingIfEmpty();
            askForReshuffle = false;
            canDraw = true;
        }
        //draw
        if ( canDraw)
        {
            Debug.Log($"{Time.time} Orchestrator draws {drawTimes} Units");
            for (int i = 0; i < drawTimes; i++)
                unitDisplay.preparing.GetComponent<Deck>().DrawFirst(unitDisplay.vigilant);
            canDraw = false;
            drawEventFree = true;
        }

    }
    public void CallOrchestrator(Effect effect)
    {
        Debug.Log($"{Time.time} Orchestrator got information that has been responded to event");
        responded = true;
        canEngageDisengage = false;
        drawTimes = effect.draw;
    }
    void ReshuffleFutureAndPreparingIfEmpty()
    {
        if(unitDisplay.preparing.transform.childCount <= 0)
        {
            Debug.Log($"{Time.time} Orchestrator reshuffling into preparing from recovering");
            unitDisplay.recovering.GetComponent<Deck>().MigrateCards(unitDisplay.preparing);
            unitDisplay.preparing.GetComponent<Deck>().Reshuffle();
        }
        if(eventStage.future.transform.childCount <= 0)
        {
            Debug.Log($"{Time.time} Orchestrator reshuffling into future from history");
            eventStage.history.GetComponent<Deck>().MigrateCards(eventStage.future);
            eventStage.future.GetComponent<Deck>().Reshuffle();
        }
    }
}
